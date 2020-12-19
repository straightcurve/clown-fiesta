using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace ClownFiesta.Core {

    [System.Serializable]
    public class TeamSelectionMenu: MonoBehaviour {
        [SerializeField] private PlayerInputManager inputManager;

        [SerializeField] private PlayerIndicator playerIndicator;
        [SerializeField] private Transform grid;

        private List<GameObject> indicators = new List<GameObject>();

        private void OnEnable() {
            Initialize();
        }

        private void AddToTeam(PlayerController controller, int team) {
            if (team == 1)
                Game.Teams.AddToFirstTeam(controller.ControlledCharacter);
            else if (team == 2)
                Game.Teams.AddToSecondTeam(controller.ControlledCharacter);
        }

        private void Close() {
            indicators.ForEach(i => Destroy(i));
            indicators.Clear();
            gameObject.SetActive(false);
        }

        private void Initialize() {
            var count = inputManager.playerCount;
            for (int i = 0; i < count; i++) {
                var indicator = Instantiate(playerIndicator.gameObject, grid).GetComponent<PlayerIndicator>();
                indicator.SetController(Game.Controllers[i]);
                indicator.SetCallback(AddToTeam);
                indicator.SetCallback(Close);

                indicators.Add(indicator.gameObject);
            }
        }
    }
}
