using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        public Transform overlay;
        public CharacterSelectionMenu menu;
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
                Controllers.Add(new PlayerController(input));
                input.transform.SetParent(transform);
                input.name = $"Player {input.playerIndex + 1}";

                var instance = Instantiate(menu.gameObject, overlay).GetComponent<CharacterSelectionMenu>();
                instance.SetPlayerIndex(input.playerIndex);

                input.actions.FindActionMap("Gameplay").FindAction("Open Team Selection Menu").started += OpenTeamSelectionNenu;
            };
        }

        private void OpenTeamSelectionNenu(InputAction.CallbackContext ctx) {
            teamSelectionMenu.gameObject.SetActive(true);
        }

        private void OnDestroy() {
            Controllers.ForEach(c => c.Input.actions.FindActionMap("Gameplay").FindAction("Open Team Selection Menu").started -= OpenTeamSelectionNenu);
        }

        public void OnCapturedObjective(CapturedEventArgs args) {
            print($"Team {args.By + 1} won!");

            SceneManager.LoadScene("debug", LoadSceneMode.Single);
        }
    }
}
