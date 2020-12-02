using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Core {

    [System.Serializable]
    public class Game {

        public List<Entity> Entities = new List<Entity>();


        public static Entity CreateEntity() {
            return new Entity();
        }
    }
}
