using System;
using System.Collections.Generic;
using Messages;
using UnityEngine;
using UnityEngine.Networking;

namespace S_Services
{
    public class S_PositionService : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        private Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>();

        public void Initialize(Dispatcher dispatcher, IServer server)
        {
            dispatcher.Connected += OnConnection;
            dispatcher.Register(MessageType.Movement, OnMovementInput);

            this.server = server;
        }

        private void OnMovementInput(NetworkReader reader, IRemotePoint sender)
        {
            var message = reader.ReadMessage<MovementInput>();
            if (!objects.ContainsKey(sender.ConnectionID))
                return;

            objects[sender.ConnectionID].transform.position += message.input * 10f * Time.deltaTime;
        }

        private void OnConnection(IRemotePoint sender)
        {
            var netObj = Instantiate(prefab);
            sender.GameObject = netObj;
            objects.Add(sender.ConnectionID, netObj);
        }

        float rate = 1 / 60f;
        float counter;
        private IServer server;

        private void Update()
        {
            if (counter < rate)
            {
                counter += Time.deltaTime;
                return;
            }

            var message = new Positions();
            foreach (var id in objects.Keys)
                message.ids.Add(id);
            foreach (var go in objects.Values)
                message.positions.Add(go.transform.position);

            server.BroadcastUnreliable(MessageType.Movement, message);

            counter = 0;
        }

    }
}