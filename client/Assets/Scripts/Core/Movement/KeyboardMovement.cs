using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownFiesta.Core.Movement {

    public class KeyboardMovement : Movement {

        protected PlayerController controller;

        protected virtual void Start() {
            controller = GetComponent<Character>().Controller;
            var move = controller.Input.actions.FindActionMap("Gameplay").FindAction("Move");
            move.performed += OnMove;
            move.canceled += OnMove;
        }

        private void OnDestroy() {
            var move = controller.Input.actions.FindActionMap("Gameplay").FindAction("Move");
            move.performed -= OnMove;
            move.canceled -= OnMove;
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
