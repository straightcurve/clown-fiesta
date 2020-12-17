using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;
using ClownFiesta.Characters.Android.Data;
using UnityEngine.InputSystem;

namespace ClownFiesta.Characters.Android {

    public class Android_LeftShift : Ability {

        [SerializeField] protected LeftShift_AndroidAbilityData data;

        private Collider2D hurtbox;
        private Movement movement;
        private Animator animator;

        protected override IEnumerator _Cast() {
            movement.CanRotate = false;

            animator.SetTrigger("LeftShift");

            var duration = data.duration;
            var invincibilityEndTime = data.invincibilityEndTime * data.duration;
            var invincibilityStartTime = data.invincibilityStartTime * data.duration;
            while (duration > 0f) {
                duration -= Time.deltaTime;

                if (IsInvulnerable && data.duration - duration > invincibilityEndTime)
                    ToggleInvulnerability(false);
                else if (!IsInvulnerable && data.duration - duration > invincibilityStartTime)
                    ToggleInvulnerability();

                yield return null;
            }

            if (invincibilityEndTime == data.duration)
                ToggleInvulnerability(false);

            movement.CanRotate = true;
        }

        public bool IsInvulnerable => !hurtbox.enabled;

        public void ToggleInvulnerability(bool invulnerable = true) {
            hurtbox.enabled = !invulnerable;
        }

        private void Awake() {
            if (movement == null)
                movement = GetComponent<Movement>();
            if (animator == null)
                animator = GetComponent<Animator>();
            if (hurtbox == null)
                hurtbox = GetComponent<Entity>()?.Hurtbox;

            if (data == null) {
                Debug.LogError("data not set");
                return;
            }

            cooldown = data.Cooldown;
            animator.SetFloat("LeftShift_AnimationSpeed", 1 / data.duration);
        }

        protected override void OnButtonPressed(InputAction.CallbackContext ctx) {
            Cast();
        }

    }
}
