using System;
using System.Collections.Generic;
using Messages;
using UnityEngine.Networking;

public class Dispatcher
{
    public delegate void OnConnection(IRemotePoint sender);
    public delegate void OnDisconnection(IRemotePoint sender);
    private Dictionary<MessageType, Action<NetworkReader, IRemotePoint>> handlers = new Dictionary<MessageType, Action<NetworkReader, IRemotePoint>>();

    public event OnConnection Connected;
    public event OnDisconnection Disconnected;

    public void Notify(MessageType type, NetworkReader reader, IRemotePoint sender)
    {
        if (handlers.ContainsKey(type))
            handlers[type](reader, sender);
    }

    public void Register(MessageType type, Action<NetworkReader, IRemotePoint> callback)
    {
        if (handlers.ContainsKey(type))
            handlers[type] += callback;
        else
            handlers.Add(type, callback);
    }

    public void Unregister(MessageType type, Action<NetworkReader, IRemotePoint> callback)
    {
        if (!handlers.ContainsKey(type))
            return;

        handlers[type] -= callback;
    }

    public void NotifyConnected(IRemotePoint sender)
    {
        Connected?.Invoke(sender);
    }

    public void NotifyDisconnected(IRemotePoint sender)
    {
        Disconnected?.Invoke(sender);
    }
}