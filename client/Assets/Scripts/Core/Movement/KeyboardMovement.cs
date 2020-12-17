using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownFiesta.Core.Movement {

    public class KeyboardMovement : Movement {

        protected override void OnEnable() {
            base.OnEnable();
        }

        protected override void FixedUpdate() {
            base.FixedUpdate();
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            Direction = ctx.ReadValue<Vector2>().normalized;
        }
    }
}
