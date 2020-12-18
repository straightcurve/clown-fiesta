using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownFiesta.Core {

    [System.Serializable]
    public class PlayerController {
        public PlayerInput Input { get; set; }
        public string Character {
            get => _character;
            set => _character = value;
        }
        [SerializeField] private string _character;


        public PlayerController(PlayerInput input) {
            Input = input;
        }

    }
}
