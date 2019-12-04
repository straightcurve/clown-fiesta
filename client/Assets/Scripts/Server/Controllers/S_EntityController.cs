using System;
using System.Collections.Generic;
using Messages;
using UnityEngine;
using UnityEngine.Networking;

namespace S_Services
{
    public class S_EntityController : MonoBehaviour
    {

        [SerializeField] GameObject prefab;
        private IServer server;
        private S_EntityService entityService;

        public void Initialize(IServer server, Dispatcher dispatcher, S_EntityService entityService)
        {
            this.server = server;
            this.entityService = entityService;
            dispatcher.Register(MessageType.Hello, OnConnection);
        }

        private void OnConnection(NetworkReader reader, IRemotePoint sender)
        {
            entityService.Spawn(prefab);
        }
    }
}