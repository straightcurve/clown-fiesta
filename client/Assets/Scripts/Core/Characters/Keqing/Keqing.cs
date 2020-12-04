using System;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;

namespace ClownFiesta.Characters.Keqing {

    [Serializable]
    public class Keqing : BaseCharacter {

        public CharacterData data;

        private Ability _Q;
        private Ability _E;
        private Ability _LeftShift;
        private Ability _Space;
        private Movement movement;


        private List<SpriteRenderer> renderers = new List<SpriteRenderer>();

        public Keqing(): base() {
            _level = 1;
        }

        public override void Hide() {
            foreach (var renderer in renderers)
                renderer.enabled = false;
        }

        public override void Show() {
            foreach (var renderer in renderers)
                renderer.enabled = true;
        }

        public Keqing Inject(GameObject owner) {
            var e = owner.GetComponent<Keqing_E>();
            e.Inject(this);
            _E = e;
            movement = owner.GetComponent<Movement>();
            owner.GetComponentsInChildren<SpriteRenderer>(renderers);

            return this;
        }

        public Keqing Inject(CharacterData data) {
            _health = _maxHealth = data.MaxHealth;

            this.data = data;

            return this;
        }

        protected override void OnDeath() {
            movement.CanMove = false;
            movement.CanRotate = false;
            // _Q.Disable();
            // _E.Disable();
            // _LeftShift.Disable();
            // _Space.Disable();
        }
    }
}
