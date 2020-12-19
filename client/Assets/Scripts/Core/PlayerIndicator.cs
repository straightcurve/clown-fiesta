using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace ClownFiesta.Core {

    public class PlayerIndicator : MonoBehaviour
    {

        /// <summary>
        ///     0: Neutral
        ///     1: First team
        ///     2: Second team
        /// </summary>
        [SerializeField] private int current = 0;
        [SerializeField] private float spacing = 200;

        private PlayerController _controller;
        private Action<PlayerController, int> _addToTeam;
        private Action _close;

        private void OnClosed(InputAction.CallbackContext ctx) {
            _close?.Invoke();
        }

        private void OnMoved(InputAction.CallbackContext ctx) {
            var direction = ctx.ReadValue<Vector2>().normalized;
            if (direction.x > 0 && current == 2)
                return;
            else if (direction.x < 0 && current == 0)
                return;

            transform.position += new Vector3(direction.x * spacing, 0, 0);
            current += (int)direction.x;
            _addToTeam?.Invoke(_controller, current);
        }

        public void SetController(PlayerController controller) {
            _controller = controller;
            _controller.Input.SwitchCurrentActionMap("Team Selection");
            _controller.Input.currentActionMap.FindAction("Move").started += OnMoved;
            _controller.Input.currentActionMap.FindAction("Close").started += OnClosed;

            current = controller.ControlledCharacter.Team + 1;
            transform.position += new Vector3(current * spacing, 0, 0);
        }

        public void SetCallback(Action<PlayerController, int> addToTeam) {
            _addToTeam = addToTeam;
        }

        public void SetCallback(Action close) {
            _close = close;
        }

        private void OnDisable() {
            if (_controller.Input == null)
                return;

            if (!_controller.Input.enabled)
                return;

            _controller.Input.SwitchCurrentActionMap("Gameplay");
            _controller.Input.actions.FindActionMap("Team Selection").FindAction("Move").started -= OnMoved;
            _controller.Input.actions.FindActionMap("Team Selection").FindAction("Close").started -= OnClosed;
        }

        private void OnDestroy() {
            if (_controller.Input == null)
                return;

            if (!_controller.Input.enabled)
                return;

            _controller.Input.SwitchCurrentActionMap("Gameplay");
            _controller.Input.actions.FindActionMap("Team Selection").FindAction("Move").started -= OnMoved;
            _controller.Input.actions.FindActionMap("Team Selection").FindAction("Close").started -= OnClosed;
        }
    }
}
