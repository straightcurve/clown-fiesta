using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownFiesta.Core {

    public class Game : MonoBehaviour
    {
        public static Vector3 MouseLocation;
        public Camera MainCamera;
        public LayerMask PlaneMask;
        public PlayerInputManager inputManager;
        public List<PlayerController> controllers = new List<PlayerController>();
        public static List<PlayerController> Controllers;
        public Transform overlay;
        public CharacterSelectionMenu menu;

        private void Update()
        {
            return;

            if (MainCamera != null)
            {
                var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, 300f, PlaneMask))
                {
                    MouseLocation = hit.point;
                }
            }
        }

        private void Awake() {
            Controllers = controllers;
        }

        private void Start() {
            Application.targetFrameRate = 300;

            inputManager.onPlayerJoined += (input) => {
                Controllers.Add(new PlayerController(input));
                input.transform.SetParent(transform);
                input.name = $"Player {input.playerIndex + 1}";

                var instance = Instantiate(menu.gameObject, overlay).GetComponent<CharacterSelectionMenu>();
                instance.SetPlayerIndex(input.playerIndex);
            };
        }
    }
}
