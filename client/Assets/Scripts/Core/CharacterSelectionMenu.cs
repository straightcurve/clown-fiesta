using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace ClownFiesta.Core {

    [System.Serializable]
    public class CharacterSelectionMenu: MonoBehaviour {
        private int playerIndex;
        [SerializeField] private InputSystemUIInputModule uiInputModule;
        [SerializeField] private MultiplayerEventSystem eventSystem;

        [SerializeField] private TMPro.TextMeshProUGUI title;
        [SerializeField] private Button selectableCharacterPrefab;
        [SerializeField] private Transform grid;

        private void Start() {
            Initialize();
        }

        public void SetPlayerIndex(int index) {
            this.playerIndex = index;
            title.text = $"Player {index + 1}";

            Game.Controllers[index].Input.uiInputModule = uiInputModule;
        }

        private void SetCharacter(Character characterPrefab) {
            //  create shit
            var character = Instantiate(characterPrefab.gameObject).GetComponent<Character>();
            character.Controller = Game.Controllers[playerIndex];
            Game.Controllers[playerIndex].ControlledCharacter = character;

            //  disable menu
            gameObject.SetActive(false);
        }

        private void Initialize() {
            var characters = Resources.LoadAll<SelectableCharacter>("Selectable Characters");
            Button first = null;
            characters.ToList().ForEach(c => {
                var button = Instantiate(selectableCharacterPrefab.gameObject, grid).GetComponent<Button>();
                button.onClick.AddListener(() => {
                    SetCharacter(c.characterPrefab);
                });
                button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = c.characterName;
                if (first == null)
                    first = button;
            });

            first.Select();
        }

    }
}
