using ClownFiesta.Core;
using UnityEngine;

namespace ClownFiesta.Networking
{
    public class NetworkManager: MonoBehaviour {

        public GameObject keqing;

        private void Awake() {
            Transport.Connect();

            Transport.Spawn += OnSpawn;
        }

        private void OnApplicationQuit() {
            Transport.Send("destroy-game");

            Transport.Cleanup();
        }

        public void OnSpawn(string id, string name, AuthorityType authority) {
            if (name.ToLower() == "keqing") {
                var entity = Instantiate(keqing).GetComponent<NetworkEntity>();
                entity.Id = id;
                entity.AuthorityType = authority;
            }
        }
    }
}
