using System;
using UnityEngine;
using UnityEngine.Events;

namespace ClownFiesta.Core {

    public class Character: MonoBehaviour {

        public CharacterData data;
        public ICharacter ActualCharacter => _ac;
        protected ICharacter _ac;

        public PlayerController Controller {
            get => controller;
            set {
                controller = value;
                ControllerChanged?.Invoke(this);
            }
        }
        protected PlayerController controller;
        public event Action<Character> ControllerChanged;

        protected Movement.Movement movement;

        protected virtual void OnEnable() {
            var movement = GetComponent<Movement.Movement>();
            if (movement == null)
                return;

            movement.CanMove = movement.CanRotate = true;
        }

        public void TakeDamage(float amount) {
            ActualCharacter.TakeDamage(amount);
        }
    }
}
