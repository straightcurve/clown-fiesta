using UnityEngine;

using System;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClownFiesta.Networking
{
    public static class Transport {

        static UdpClient client;

        // static bool connected = false;
        static bool connected => client.Client.Connected;

        public static void Connect() {
            client = new UdpClient(6001);
            try {
                client.Connect("127.0.0.1", 6000);

                // connected = true;

                Task.Run(() => {
                    Receive();
                });

                // Sends a message to the host to which you have connected.
                // Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");

                // client.Send(sendBytes, sendBytes.Length);

                // //IPEndPoint object will allow us to read datagrams sent from any source.
                // IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // // Blocks until a message returns on this socket from a remote host.
                // Byte[] receiveBytes = client.Receive(ref RemoteIpEndPoint);
                // string returnData = Encoding.ASCII.GetString(receiveBytes);

                // // Uses the IPEndPoint object to determine which of these two hosts responded.
                // Console.WriteLine("This is the message you received " +
                //                             returnData.ToString());
                // Console.WriteLine("This message was sent from " +
                //                             RemoteIpEndPoint.Address.ToString() +
                //                             " on their port number " +
                //                             RemoteIpEndPoint.Port.ToString());

                }
            catch (Exception e) {
                Debug.Log(e.ToString());
            }
        }

        public static event Action<string, float, float> PositionUpdate;
        public static event Action<string, string, AuthorityType> Spawn;

        private static void Receive() {
            while(connected) {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = client.Receive(ref RemoteIpEndPoint);
                string message = Encoding.ASCII.GetString(receiveBytes);

                var index = message.IndexOf("positions");
                if (index != -1) {
                    message = message.Remove(index, "positions|".Length);
                    var poss = JsonUtility.FromJson<Poss>(message);

                    Threading.Queue(() => {
                        poss.positions.ForEach(pos => {
                            PositionUpdate?.Invoke(pos.id, pos.x, pos.y);
                        });
                    });
                }

                index = message.IndexOf("spawn");
                if (index != -1) {
                    Debug.Log(message);
                    message = message.Remove(index, "spawn".Length);
                    var id = message.Split('|')[0];
                    var name = message.Split('|')[1];
                    var authority = message.Split('|')[2];

                    Threading.Queue(() => {
                        Spawn?.Invoke(id, name, authority == "local" ? AuthorityType.Local : AuthorityType.Remote);
                    });
                }
            }
        }

        public static void Send(string message) {
            if (!connected)
                return;

            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            client.Send(sendBytes, sendBytes.Length);
        }

        public static void Cleanup() {
            // connected = false;
            client.Close();
        }

    }
}

[Serializable]
class Poss {
    public List<Pos> positions;
}

[Serializable]
class Pos {
    public string id;
    public float x;
    public float y;
}
