using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

namespace ClownFiesta.Core.UI.Team {

    public class PlayerIndicator : MonoBehaviour
    {

        /// <summary>
        ///     0: Neutral
        ///     1: First team
        ///     2: Second team
        /// </summary>
        private int current = 0;
        [SerializeField] private Text[] texts = new Text[3];

        private PlayerController _controller;
        private Action<PlayerController, int> _addToTeam;


        private void OnMoved(InputAction.CallbackContext ctx) {
            var direction = ctx.ReadValue<Vector2>().normalized;
            if (direction.x > 0 && current == 2)
                return;
            else if (direction.x < 0 && current == 0)
                return;

            current += (int)direction.x;
            transform.position = new Vector3(texts[current].transform.position.x, transform.position.y, transform.position.z);
            _addToTeam?.Invoke(_controller, current);
        }

        public void SetController(PlayerController controller) {
            _controller = controller;
            _controller.Input.currentActionMap.FindAction("Move").started += OnMoved;

            current = controller.ControlledCharacter.Team + 1;
            transform.position = new Vector3(texts[current].transform.position.x, transform.position.y, transform.position.z);
        }

        public void SetCallback(Action<PlayerController, int> addToTeam) {
            _addToTeam = addToTeam;
        }

        private void OnEnable() {
            if (_controller == null)
                return;
            if (_controller.Input == null)
                return;

            _controller.Input.currentActionMap.FindAction("Move").started += OnMoved;
        }

        private void OnDisable() {
            if (_controller.Input == null)
                return;

            if (!_controller.Input.enabled)
                return;

            _controller.Input.actions.FindActionMap("UI").FindAction("Move").started -= OnMoved;
        }

        private void OnDestroy() {
            if (_controller.Input == null)
                return;

            if (!_controller.Input.enabled)
                return;

            _controller.Input.actions.FindActionMap("UI").FindAction("Move").started -= OnMoved;
        }
    }
}
