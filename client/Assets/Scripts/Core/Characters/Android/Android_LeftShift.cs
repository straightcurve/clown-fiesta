using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;

namespace ClownFiesta.Characters.Android {

    public class Android_LeftShift : Ability {

        private Collider2D hurtbox;
        private Movement movement;
        private Animator animator;

        public void Cast() {
            movement.CanRotate = false;

            animator.SetTrigger("LeftShift");
        }

        public void OnAnimationFinished_LeftShift() {
            movement.CanRotate = true;

            print("finished");
        }

        public void Activate_LeftShift() {
            hurtbox.enabled = false;
        }

        public void Deactivate_LeftShift() {
            hurtbox.enabled = true;

            print("deactivated");
        }

        private void OnEnable() {
            if (movement == null)
                movement = GetComponent<Movement>();
            if (animator == null)
                animator = GetComponent<Animator>();
            if (hurtbox == null)
                hurtbox = GetComponent<Entity>()?.Hurtbox;
        }

        private void Update() {
            if (!_enabled)
                return;

            if (Input.GetKeyDown(KeyCode.LeftShift))
                Cast();
        }

    }
}
