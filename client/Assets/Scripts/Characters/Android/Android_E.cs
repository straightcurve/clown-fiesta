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

        protected override IEnumerator _Cast() {
            movement.CanMove = false;
            movement.CanRotate = false;

            animator.SetTrigger("E");

            var duration = data.duration;
            var anticipationTime = data.anticipationTime * data.duration;
            var returnTime = data.returnTime * data.duration;
            while (duration > 0f) {
                duration -= Time.deltaTime;

                if (CanDealDamage && data.duration - duration > returnTime)
                    hitbox.Deactivate();
                else if (!CanDealDamage && data.duration - duration > anticipationTime)
                    hitbox.Activate();

                yield return null;
            }

            if (returnTime == data.duration)
                hitbox.Deactivate();

            movement.CanMove = true;
            movement.CanRotate = true;
        }

        public bool CanDealDamage => hitbox.IsActive;

        private void Awake() {
            if (movement == null)
                movement = GetComponent<Movement>();
            if (animator == null)
                animator = GetComponent<Animator>();

            if (data == null) {
                Debug.LogError("data not set");
                return;
            }

            cooldown = data.Cooldown;
            animator.SetFloat("E_AnimationSpeed", 1 / data.duration);
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
