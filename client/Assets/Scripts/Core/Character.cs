using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Characters.Android;

namespace ClownFiesta.Core {

    public class Character : MonoBehaviour {

        public CharacterData data;
        public BaseCharacter ActualCharacter => _ac;
        private BaseCharacter _ac;

        private Movement.Movement movement;

        protected virtual void OnEnable() {
            var movement = GetComponent<Movement.Movement>();
            if (movement == null)
                return;

            movement.CanMove = movement.CanRotate = true;
        }

        protected virtual void Awake() {
            _ac = new Android(gameObject, data);
        }

        public void TakeDamage(float amount) {
            ActualCharacter.TakeDamage(amount);
        }
    }
}

public class FloatEvent : UnityEvent<float> { }