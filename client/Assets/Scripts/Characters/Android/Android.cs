using System;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;

namespace ClownFiesta.Characters.Android {

    [Serializable]
    public class Android : BaseCharacter {

        public CharacterData data;

        private Android_Q _Q;
        private Android_E _E;
        private Android_LeftShift _LeftShift;
        private Android_Space _Space;
        private Movement movement;

        public Android(GameObject owner, CharacterData data): base() {
            _Q = owner.GetComponent<Android_Q>();
            _E = owner.GetComponent<Android_E>();
            _LeftShift = owner.GetComponent<Android_LeftShift>();
            _Space = owner.GetComponent<Android_Space>();
            movement = owner.GetComponent<Movement>();

            _maxHealth = data.MaxHealth;

            this.data = data;

            RestoreFullHealth();
        }

        public float PassiveMultiplier {
            get {
                if (Level == 25)
                    return 9999.99f;

                if (Level >= 20)
                    return 1f;

                if (Level >= 10)
                    return .75f;

                return .5f;
            }
        }

        public override void TakeDamage(float amount) {
            //  apply passive here
            amount = amount + amount * PassiveMultiplier;

            base.TakeDamage(amount);
        }

        protected override void OnDeath() {
            movement.CanMove = false;
            movement.CanRotate = false;
            _Q.Disable();
            _E.Disable();
            _LeftShift.Disable();
            _Space.Disable();
        }
    }
}
