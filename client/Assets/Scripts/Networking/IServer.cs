using Messages;
using UnityEngine.Networking;

public interface IServer
{
    void BroadcastUnreliable(MessageType messageType, MessageBase message);
    void BroadcastReliable(MessageType messageType, MessageBase message);
}