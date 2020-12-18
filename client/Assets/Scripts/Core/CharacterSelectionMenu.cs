using UnityEngine;
using UnityEngine.InputSystem.UI;

namespace ClownFiesta.Core {

    [System.Serializable]
    public class CharacterSelectionMenu: MonoBehaviour {
        private int playerIndex;
        [SerializeField] private InputSystemUIInputModule uiInputModule;

        [SerializeField] private TMPro.TextMeshProUGUI title;

        public void SetPlayerIndex(int index) {
            this.playerIndex = index;
            title.text = $"Player {index + 1}";

            Game.Controllers[index].Input.uiInputModule = uiInputModule;
        }

        public void SetCharacter(string character) {
            Game.Controllers[playerIndex].Character = character;

            //  create shit
            var instance = Instantiate(Resources.Load<GameObject>("Prefabs/Keqing/Keqing")).GetComponent<Character>();
            instance.Controller = Game.Controllers[playerIndex];

            //  disable menu
            gameObject.SetActive(false);
        }

    }
}
