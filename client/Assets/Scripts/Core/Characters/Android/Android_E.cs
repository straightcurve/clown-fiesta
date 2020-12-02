using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;

namespace ClownFiesta.Characters.Android {

    public class Android_E : Ability {

        public Hitscan hitbox;

        private Movement movement;
        private Animator animator;

        public void Cast() {
            movement.CanMove = false;
            movement.CanRotate = false;

            animator.SetTrigger("E");
        }

        public void OnAnimationFinished_E() {
            movement.CanMove = true;
            movement.CanRotate = true;

            print("finished");
        }

        public void Activate_E() {
            hitbox.Activate();
        }

        public void Deactivate_E() {
            hitbox.Deactivate();

            print("deactivated");
        }

        private void OnEnable() {
            if (movement == null)
                movement = GetComponent<Movement>();
            if (animator == null)
                animator = GetComponent<Animator>();
        }

        private void Update() {
            if (!_enabled)
                return;

            if (Input.GetKeyDown(KeyCode.E))
                Cast();
        }

    }
}
