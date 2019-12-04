using System;
using System.Collections.Generic;
using Messages;
using UnityEngine;

namespace S_Services
{
    public class S_EntityService : MonoBehaviour
    {

        private readonly Dictionary<Guid, IEntity> entities = new Dictionary<Guid, IEntity>();
        private IServer server;

        public void Initialize(IServer server, Dispatcher dispatcher)
        {
            this.server = server;
        }

        public void Spawn(GameObject go)
        {
            //  get an id
            //  spawn the object
            //  initialize with id and other required data
            //  add to map of entities
            //  broadcast to clients

            var id = Guid.NewGuid();
            var entity = Instantiate(go).GetComponent<IEntity>();
            entity.Initialize(id);
            entities.Add(id, entity);
            server.BroadcastReliable(MessageType.Entity_Create, new EntityCreate(id));
        }

        public void Destroy(Guid id)
        {
            if (!entities.ContainsKey(id))
            {
                Debug.LogError($"No entity with id {id} could be found.");
                return;
            }

            entities[id].Destroy();
            entities.Remove(id);
            server.BroadcastReliable(MessageType.Entity_Destroy, new EntityDestroy(id));
        }
    }
}