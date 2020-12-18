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
            movement = owner.GetComponent<Movement>();
            owner.GetComponentsInChildren<SpriteRenderer>(renderers);
            owner.GetComponent<Character>().ControllerChanged += SetupAbilityControls;

            return this;
        }

        public Keqing Inject(CharacterData data) {
            _health = _maxHealth = data.MaxHealth;

            this.data = data;

            return this;
        }

        private void SetupAbilityControls(Character owner) {
            var controls = owner.Controller.Input.actions;
            var e = owner.GetComponent<Keqing_E>();
            e.Inject(this)
             .Inject(controls.FindActionMap("Gameplay").FindAction("E"));
            _E = e;

            var q = owner.GetComponent<Keqing_Q>();
            q.Inject(controls.FindActionMap("Gameplay").FindAction("Q"));
            _Q = q;
        }

        protected override void OnDeath() {
            movement.CanMove = false;
            movement.CanRotate = false;
            if (_Q != null)
                _Q.Disable();
            if (_E != null)
                _E.Disable();
            if (_LeftShift != null)
                _LeftShift.Disable();
            if (_Space != null)
                _Space.Disable();
        }
    }
}
