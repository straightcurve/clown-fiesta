using ClownFiesta.Core.UI;
using UnityEngine;

namespace ClownFiesta.Core {

    public class TeamMenu: MonoBehaviour, IMenu {
        [SerializeField] private PlayerIndicator indicator;
        [SerializeField] private Transform grid;

        public PlayerController Controller {
            get => controller;
            set {
                controller = value;
            }
        }
        private PlayerController controller;

        public bool Selectable => Controller != null && Controller.ControlledCharacter != null;

        private void Start() {
            Initialize();
        }

        private void AddToTeam(PlayerController controller, int team) {
            if (team == 1)
                Game.Teams.AddToFirstTeam(controller.ControlledCharacter);
            else if (team == 2)
                Game.Teams.AddToSecondTeam(controller.ControlledCharacter);
        }

        private void Close() {
            gameObject.SetActive(false);
        }

        private void Initialize() {
            indicator.SetController(Controller);
            indicator.SetCallback(AddToTeam);
        }
    }
}
