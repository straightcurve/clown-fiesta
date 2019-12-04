using System;
using System.Collections.Generic;
using Messages;
using UnityEngine;
using UnityEngine.Networking;

public interface IClient
{
    int HostID { get; }
    int ConnectionID { get; }

    void Connect();
    void Disconnect();
    void Send(MessageType messageType, MessageBase message);
}

public class Client : MonoBehaviour, IClient
{
    [SerializeField] int port = 5000;
    private Dictionary<QosType, byte> channels = new Dictionary<QosType, byte>();
    private Dispatcher dispatcher;
    private int recHostId;

    public void Initialize(Dispatcher dispatcher)
    {
        this.dispatcher = dispatcher;

        GlobalConfig gConfig = new GlobalConfig();
        gConfig.MaxPacketSize = 6000;
        NetworkTransport.Init(gConfig);

        ConnectionConfig config = new ConnectionConfig();
        channels.Add(QosType.Reliable, config.AddChannel(QosType.Reliable));
        channels.Add(QosType.Unreliable, config.AddChannel(QosType.Unreliable));

        HostTopology topology = new HostTopology(config, 10);
        this.HostID = NetworkTransport.AddHost(topology, port);

        Connect();
    }

    public int HostID { get; private set; }
    public int ConnectionID { get; private set; } = -1;

    private void Awake()
    {

    }

    private void OnDestroy()
    {
        Disconnect();
        NetworkTransport.Shutdown();
    }

    public void Connect()
    {
        ConnectionID = NetworkTransport.Connect(HostID, "127.0.0.1", 6000, 0, out var error);
        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.LogError((NetworkError)error);
        }
    }

    public void Send(MessageType messageType, MessageBase message)
    {
        var writer = new NetworkWriter();
        writer.Write((byte)messageType);
        writer.Write(message);

        var buffer = writer.AsArray();
        NetworkTransport.Send(recHostId, ConnectionID, channels[QosType.Reliable], buffer, buffer.Length, out var error);
        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.LogError((NetworkError)error);
        }
    }

    public void Disconnect()
    {
        NetworkTransport.Disconnect(HostID, ConnectionID, out var error);
        if ((NetworkError)error != NetworkError.Ok)
        {
            Debug.LogError((NetworkError)error);
        }
    }

    private void Update()
    {
        if (ConnectionID == -1)
            return;

        int connectionId;
        int channelId;
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;

        var sender = new RemotePoint();
        sender.reliable = channels[QosType.Reliable];
        sender.unreliable = channels[QosType.Unreliable];

        NetworkEventType recData = NetworkTransport.Receive(out sender.recHostId, out sender.connectionID, out channelId, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {
            case NetworkEventType.Nothing: break;
            case NetworkEventType.ConnectEvent:
                if (sender.connectionID == ConnectionID)
                {
                    //  connection approved
                    Send(MessageType.Hello, new Hello("HEY THERE! IM A CLIENT!"));
                }
                else
                {
                    //  someone sent a connection request to me
                }
                break;
            case NetworkEventType.DataEvent:
                var reader = new NetworkReader(recBuffer);
                dispatcher.Notify((MessageType)reader.ReadByte(), reader, sender);
                break;
            case NetworkEventType.DisconnectEvent:
                if (sender.connectionID == ConnectionID)
                {
                    //  connection error
                    Debug.LogError((NetworkError)error);
                }
                else
                {
                    //  someone disconnected from me
                }
                break;

            case NetworkEventType.BroadcastEvent:

                break;
        }
    }
}

public interface IRemotePoint
{
    int ConnectionID { get; }
    Guid ID { get; }
    GameObject GameObject { get; set; }

    void SendReliable(MessageType messageType, MessageBase message);
}