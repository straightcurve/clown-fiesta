using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Networking {

    public class NetworkedMovement : MonoBehaviour {

        private new Rigidbody2D rigidbody;
        private NetworkEntity entity;

        private void Awake() {
            rigidbody = GetComponent<Rigidbody2D>();
            entity = GetComponent<NetworkEntity>();

            Transport.PositionUpdate += OnPositionUpdate;
        }

        private void OnPositionUpdate(string id, float x, float y) {
            if (entity.Id != id)
                return;

            rigidbody.position = new Vector2(x, y);
        }

        private void Update() {
            if (entity.AuthorityType == AuthorityType.Remote)
                return;

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            Transport.Send($"move|{entity.Id}|{x}|{y}");
        }
    }
}
