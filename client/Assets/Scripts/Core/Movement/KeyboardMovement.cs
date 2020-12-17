using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownFiesta.Core.Movement {

    public class KeyboardMovement : Movement {

        protected CharacterControls controls;

        protected virtual void Start() {
            controls = this.GetComponent<Character>().controls;
            controls.Gameplay.Move.performed += OnMove;
            controls.Gameplay.Move.canceled += OnMove;
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
