using System.Collections.Generic;
using ClownFiesta.Core.UI;
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
        public Teams teams = new Teams();
        public static Teams Teams;
        public Transform splitMenuOverlay;
        public Menu menu;
        public TeamSelectionMenu teamSelectionMenu;

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
            Teams = teams;
        }

        private void Start() {
            Application.targetFrameRate = 300;

            inputManager.onPlayerJoined += (input) => {
                var controller = new PlayerController(input);
                Controllers.Add(controller);

                input.transform.SetParent(transform);
                input.name = $"Player {input.playerIndex + 1}";

                var instance = Instantiate(menu.gameObject, splitMenuOverlay).GetComponent<Menu>();
                instance.Controller = controller;

                input.SwitchCurrentActionMap("UI");

                input.actions.FindActionMap("Gameplay").FindAction("Open Team Selection Menu").started += OpenTeamSelectionNenu;
            };
        }

        private void OpenTeamSelectionNenu(InputAction.CallbackContext ctx) {
            teamSelectionMenu.gameObject.SetActive(true);
        }

        private void OnDestroy() {
            Controllers.ForEach(c => c.Input.actions.FindActionMap("Gameplay").FindAction("Open Team Selection Menu").started -= OpenTeamSelectionNenu);
        }
    }
}
