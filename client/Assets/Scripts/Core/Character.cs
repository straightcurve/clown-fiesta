using System;
using UnityEngine;
using UnityEngine.Events;

namespace ClownFiesta.Core {

    public class Character: MonoBehaviour {

        public CharacterData data;
        public ICharacter ActualCharacter => _ac;
        protected ICharacter _ac;

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
