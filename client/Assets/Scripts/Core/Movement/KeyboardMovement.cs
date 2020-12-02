using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Core.Movement {

    public class KeyboardMovement : Movement {

        protected override void OnEnable() {
            base.OnEnable();
        }

        protected override void FixedUpdate() {
            base.FixedUpdate();
        }

        protected override void Update() {
            Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Direction.Normalize();

            base.Update();
        }

    }
}
