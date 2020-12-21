using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ClownFiesta.Core.UI {

    public class CharacterMenu: MonoBehaviour, IMenu {

        [SerializeField] private Button selectableCharacterPrefab;
        [SerializeField] private Transform grid;

        public PlayerController Controller {
            get => controller;
            set {
                controller = value;
            }
        }
        private PlayerController controller;

        private void Start() {
            Initialize();
        }

        private void SetCharacter(Character characterPrefab) {
            if (Controller.ControlledCharacter != null)
                Destroy(Controller.ControlledCharacter.gameObject);

            var character = Instantiate(characterPrefab.gameObject).GetComponent<Character>();
            character.Controller = Controller;
            Controller.ControlledCharacter = character;
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
