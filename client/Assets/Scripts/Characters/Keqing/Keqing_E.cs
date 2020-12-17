using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;
using ClownFiesta.Characters.Keqing.Data;
using UnityEngine.InputSystem;

namespace ClownFiesta.Characters.Keqing {

    public class Keqing_E : Ability {

        [SerializeField] protected E_KeqingAbilityData data;
        [SerializeField] protected LineRenderer lineRenderer;

        protected Keqing keqing;

        private Movement movement;
        private Animator animator;

        private readonly Collider2D[] targets = new Collider2D[16];
        private readonly List<Character> unique = new List<Character>();

        protected override IEnumerator _Cast() {
            //  disable movement and rotation
            //  hide our character
            //  cache initial position

            //  get targets in range
            //  compute lines between targets
            //  spawn line renderers and deal damage to 2 targets at a time
            //  spawn clone near the enemies attacked

            //  return our character to the initial position
            //  display our character
            //  enable movement and rotation
            CanControlCharacter(false);

            keqing.Hide();

            var position = transform.position;
            var radius = data.radius;

            if (PopulateUniqueTargetsList(position, radius) == 0) {
                keqing.Show();

                CanControlCharacter();

                yield break;
            }

            var damage = data.damage;
            var finalSlashDamage = data.finalSlashDamage;
            var delayBetweenSlashes = data.delayBetweenSlashes;
            var clonePrefab = data.clonePrefab;
            var distanceBehindTarget = data.distanceBehindTarget;
            int c = 0;

            Action<float> dealDamage = new Action<float>((x) => {});
            unique.ForEach(ch => dealDamage += ch.TakeDamage);

            //  TODO: jump to furthest

            lineRenderer.positionCount = 2;
            var slashOrigin = transform.position;
            Vector3 distance;
            float mag;
            for (c = 0; c < unique.Count - 1; c++)
            {
                lineRenderer.SetPosition(0, unique[c].transform.position);
                yield return HandleSlashEffect(damage);

                lineRenderer.SetPosition(1, unique[++c].transform.position);
                yield return HandleSlashEffect(damage);
            }

            if ((unique.Count & 1) == 1) {
                lineRenderer.SetPosition(0, unique[c - 1].transform.position);
                slashOrigin = unique[c - 1].transform.position;

                lineRenderer.SetPosition(1, unique[c].transform.position);
                yield return HandleSlashEffect(finalSlashDamage);
            }

            lineRenderer.positionCount = 0;
            unique.Clear();

            transform.position = position;

            keqing.Show();

            CanControlCharacter();



            GameObject SpawnCloneAtPosition(Vector3 pos) {
                var clone = Instantiate(clonePrefab);
                clone.transform.position = pos;
                return clone;
            }

            IEnumerator HandleSlashEffect(float damageValue) {
                dealDamage(damageValue);
                distance = (unique[c].transform.position - slashOrigin);
                mag = distance.magnitude + distanceBehindTarget;
                SpawnCloneAtPosition(slashOrigin + distance.normalized * mag);
                slashOrigin = unique[c].transform.position;
                yield return new WaitForSeconds(delayBetweenSlashes);
            }
        }

        private int PopulateUniqueTargetsList(Vector3 position, float radius) {
            //  TODO: Layermask            
            int len = Physics2D.OverlapCircleNonAlloc(position, radius, targets);
            for (int t = 0; t < len; t++) {
                var root = targets[t].transform.root.gameObject;
                if (root == gameObject)
                    continue;

                var character = root.GetComponent<Character>();
                if (character == null)
                    continue;
                if (unique.Contains(character))
                    continue;

                unique.Add(character);
            }
            return unique.Count;
        }

        private void CanControlCharacter(bool canControl = true) {
            movement.CanMove = movement.CanRotate = canControl;
        }

        public Keqing_E Inject(Keqing keqing) {
            this.keqing = keqing;
            return this;
        }

        private void Start() {
            if (movement == null)
                movement = GetComponent<Movement>();
            if (animator == null)
                animator = GetComponent<Animator>();

            if (data == null) {
                Debug.LogError("data not set");
                return;
            }

            var color = data.lineColor;
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            lineRenderer.startWidth = 0.3f;
            lineRenderer.endWidth = 0.3f;

            cooldown = data.Cooldown;
            // animator.SetFloat("E_AnimationSpeed", 1 / data.duration);
        }

        protected override void OnButtonPressed(InputAction.CallbackContext ctx) {
            Cast();
        }
    }
}
