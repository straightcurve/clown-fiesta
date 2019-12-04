using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Messages;
using UnityEngine;
using UnityEngine.Networking;

public class Server : MonoBehaviour, IServer
{
    public static Dictionary<QosType, byte> Channels => channels;


    [SerializeField] int port = 6000;
    private static Dictionary<QosType, byte> channels = new Dictionary<QosType, byte>();
    private List<int> connections = new List<int>();
    private Dispatcher dispatcher;


    public void Initialize(Dispatcher dispatcher)
    {
        this.dispatcher = dispatcher;
        dispatcher.Register(MessageType.Hello, Handle_Hello);

        GlobalConfig gConfig = new GlobalConfig();
        gConfig.MaxPacketSize = 6000;
        NetworkTransport.Init(gConfig);

        ConnectionConfig config = new ConnectionConfig();
        channels.Add(QosType.Reliable, config.AddChannel(QosType.Reliable));
        channels.Add(QosType.Unreliable, config.AddChannel(QosType.Unreliable));

        HostTopology topology = new HostTopology(config, 10);
        HostID = NetworkTransport.AddHost(topology, port);
    }

    public static int HostID { get; private set; }

    private void Handle_Hello(NetworkReader reader, IRemotePoint sender)
    {
        var x = reader.ReadMessage<Hello>();
        print($"{sender.ConnectionID} sent {x.message}");
    }

    private void OnDestroy()
    {
        NetworkTransport.Shutdown();
    }

    [Obsolete]
    public void SendReliable(MessageType messageType, MessageBase message, int id)
    {
        var writer = new NetworkWriter();
        writer.Write((byte)messageType);
        writer.Write(message);

        var buffer = writer.AsArray();
        NetworkTransport.Send(HostID, id, channels[QosType.Reliable], buffer, buffer.Length, out var error);
        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.LogError($"{messageType} {(NetworkError)error}");
        }
    }

    [Obsolete]
    public void SendUnreliable(MessageType messageType, MessageBase message, int id)
    {
        var writer = new NetworkWriter();
        writer.Write((byte)messageType);
        writer.Write(message);

        var buffer = writer.AsArray();
        NetworkTransport.Send(HostID, id, channels[QosType.Unreliable], buffer, buffer.Length, out var error);
        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.LogError($"{messageType} {(NetworkError)error}");
        }
    }

    private void Update()
    {
        int channelId;      //  which channel has the data been sent on?
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;

        var remote = new RemotePoint();
        remote.reliable = Channels[QosType.Reliable];
        remote.unreliable = Channels[QosType.Unreliable];

        NetworkEventType recData = NetworkTransport.Receive(out remote.recHostId, out remote.connectionID, out channelId, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {
            case NetworkEventType.Nothing: break;
            case NetworkEventType.ConnectEvent:
                Debug.Log($"{remote.ConnectionID} has connected");
                break;
            case NetworkEventType.DataEvent:
                var reader = new NetworkReader(recBuffer);
                dispatcher.Notify((MessageType)reader.ReadByte(), reader, remote);
                break;
            case NetworkEventType.DisconnectEvent:
                //  someone disconnected from me
                Debug.Log($"{remote.ConnectionID} has disconnected");
                connections.Remove(remote.connectionID);
                dispatcher.NotifyDisconnected(remote);
                break;

            case NetworkEventType.BroadcastEvent:

                break;
        }
    }

    public void BroadcastReliable(MessageType messageType, MessageBase message)
    {
        var writer = new NetworkWriter();
        writer.Write((byte)messageType);
        writer.Write(message);

        var buffer = writer.AsArray();
        Parallel.ForEach(connections, connection => NetworkTransport.Send(HostID, connection, channels[QosType.Reliable], buffer, buffer.Length, out var error));
    }

    public void BroadcastUnreliable(MessageType messageType, MessageBase message)
    {
        var writer = new NetworkWriter();
        writer.Write((byte)messageType);
        writer.Write(message);

        var buffer = writer.AsArray();
        Parallel.ForEach(connections, connection => NetworkTransport.Send(HostID, connection, channels[QosType.Unreliable], buffer, buffer.Length, out var error));
    }
}

public struct RemotePoint : IRemotePoint
{
    public int recHostId; //  web or standalone

    public byte reliable;
    public byte unreliable;
    public int connectionID;
    public int ConnectionID => connectionID;

    public Guid ID { get; set; }
    public GameObject GameObject { get; set; }

    public void SendReliable(MessageType messageType, MessageBase message)
    {
        var writer = new NetworkWriter();
        writer.Write((byte)messageType);
        writer.Write(message);

        var buffer = writer.AsArray();
        NetworkTransport.Send(recHostId, ConnectionID, reliable, buffer, buffer.Length, out var error);
        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.LogError($"{messageType} {(NetworkError)error}");
        }
    }

    public void SendUnreliable(MessageType messageType, MessageBase message)
    {
        var writer = new NetworkWriter();
        writer.Write((byte)messageType);
        writer.Write(message);

        var buffer = writer.AsArray();
        NetworkTransport.Send(recHostId, ConnectionID, unreliable, buffer, buffer.Length, out var error);
        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.LogError($"{messageType} {(NetworkError)error}");
        }
    }
}