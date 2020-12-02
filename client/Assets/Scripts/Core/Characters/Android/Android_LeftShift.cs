using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;

namespace ClownFiesta.Characters.Android {

    public class Android_LeftShift : Ability {

        private Collider2D hurtbox;
        private Movement movement;
        private Animator animator;

        private bool animationFinished;

        protected override IEnumerator _Cast() {
            movement.CanRotate = false;

            animator.SetTrigger("LeftShift");

            while (!animationFinished)
                yield return null;

            movement.CanRotate = true;
            animationFinished = false;
        }

        public void OnAnimationFinished_LeftShift() {
            animationFinished = true;
        }

        public void Activate_LeftShift() {
            hurtbox.enabled = false;
        }

        public void Deactivate_LeftShift() {
            hurtbox.enabled = true;
        }

        private void OnEnable() {
            if (movement == null)
                movement = GetComponent<Movement>();
            if (animator == null)
                animator = GetComponent<Animator>();
            if (hurtbox == null)
                hurtbox = GetComponent<Entity>()?.Hurtbox;
        }

        protected override void Update() {
            base.Update();

            if (!_enabled)
                return;

            if (Input.GetKeyDown(KeyCode.LeftShift))
                Cast();
        }

    }
}
