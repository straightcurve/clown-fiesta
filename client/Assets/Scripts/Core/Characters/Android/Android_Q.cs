using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;

namespace ClownFiesta.Characters.Android {

    public class Android_Q : Ability {

        public Hitscan hitbox;

        private Movement movement;
        private Animator animator;

        private bool animationFinished;

        protected override IEnumerator _Cast() {
            movement.CanMove = false;
            movement.CanRotate = false;

            animator.SetTrigger("Q");

            while (!animationFinished)
                yield return null;

            movement.CanMove = true;
            movement.CanRotate = true;
            animationFinished = false;
        }

        public void OnAnimationFinished_Q() {
            animationFinished = true;
        }

        public void Activate_Q() {
            hitbox.Activate();
        }

        public void Deactivate_Q() {
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

            if (Input.GetKeyDown(KeyCode.Q))
                Cast();
        }

    }
}
