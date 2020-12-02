using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;
using ClownFiesta.Characters.Android.Data;

namespace ClownFiesta.Characters.Android {

    public class Android_E : Ability {

        [SerializeField] protected E_AndroidAbilityData data;

        public Hitscan hitbox;

        private Movement movement;
        private Animator animator;

        private bool animationFinished;

        private void Awake() {
            if (data == null) {
                Debug.LogError("data not set");
                return;
            }

            cooldown = data.Cooldown;
        }

        protected override IEnumerator _Cast() {
            movement.CanMove = false;
            movement.CanRotate = false;

            animator.SetTrigger("E");

            while (!animationFinished)
                yield return null;

            movement.CanMove = true;
            movement.CanRotate = true;
            animationFinished = false;
        }

        public void OnAnimationFinished_E() {
            animationFinished = true;
        }

        public void Activate_E() {
            hitbox.Activate();
        }

        public void Deactivate_E() {
            hitbox.Deactivate();
        }

        private void OnEnable() {
            if (movement == null)
                movement = GetComponent<Movement>();
            if (animator == null)
                animator = GetComponent<Animator>();
        }

        protected override void Update() {
            base.Update();

            if (!_enabled)
                return;

            if (Input.GetKeyDown(KeyCode.E))
                Cast();
        }

    }
}
