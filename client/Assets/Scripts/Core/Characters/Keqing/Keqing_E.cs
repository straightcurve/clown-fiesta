using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;
using ClownFiesta.Characters.Keqing.Data;

namespace ClownFiesta.Characters.Keqing {

    public class Keqing_E : Ability {

        [SerializeField] protected E_KeqingAbilityData data;
        [SerializeField] protected LineRenderer lineRenderer;
        
        protected Keqing keqing;

        private Movement movement;
        private Animator animator;

        private readonly List<Character> unique = new List<Character>();
        private readonly List<GameObject> clones = new List<GameObject>();

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

            movement.CanMove = movement.CanRotate = false;

            keqing.Hide();

            var position = transform.position;
            var radius = data.radius;

            //  TODO: Layermask
            var targets = Physics2D.OverlapCircleAll(position, radius);
            if (targets.Length > 0) {
                for (int t = 0; t < targets.Length; t++)
                {
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

                lineRenderer.positionCount = 2;
                var damage = data.damage;
                var finalSlashDamage = data.finalSlashDamage;
                var delayBetweenSlashes = data.delayBetweenSlashes;
                var clonePrefab = data.clonePrefab;
                var distanceBehindTarget = data.distanceBehindTarget;
                int c = 0;

                Action<float> dealDamage = new Action<float>((x) => {});
                unique.ForEach(ch => dealDamage += ch.TakeDamage);

                //  TODO: jump to furthest

                var slashOrigin = transform.position;
                Vector3 distance;
                float mag;
                for (c = 0; c < unique.Count - 1; c++)
                {
                    lineRenderer.SetPosition(0, unique[c].transform.position);
                    dealDamage(damage);
                    distance = (unique[c].transform.position - slashOrigin);
                    mag = distance.magnitude + distanceBehindTarget;
                    clones.Add(CreateClone(slashOrigin + distance.normalized * mag));
                    slashOrigin = unique[c].transform.position;
                    yield return new WaitForSeconds(delayBetweenSlashes);

                    lineRenderer.SetPosition(1, unique[++c].transform.position);
                    dealDamage(damage);
                    distance = (unique[c].transform.position - slashOrigin);
                    mag = distance.magnitude + distanceBehindTarget;
                    clones.Add(CreateClone(slashOrigin + distance.normalized * mag));
                    slashOrigin = unique[c].transform.position;
                    yield return new WaitForSeconds(delayBetweenSlashes);
                }

                if ((unique.Count & 1) == 1) {
                    lineRenderer.SetPosition(0, unique[c - 1].transform.position);
                    slashOrigin = unique[c - 1].transform.position;

                    lineRenderer.SetPosition(1, unique[c].transform.position);
                    dealDamage(finalSlashDamage);
                    distance = (unique[c].transform.position - slashOrigin);
                    mag = distance.magnitude + distanceBehindTarget;
                    clones.Add(CreateClone(slashOrigin + distance.normalized * mag));
                    slashOrigin = unique[c].transform.position;
                    yield return new WaitForSeconds(delayBetweenSlashes);
                }

                lineRenderer.positionCount = 0;
                
                unique.Clear();
                clones.Clear();

                GameObject CreateClone(Vector3 pos) {
                    var clone = Instantiate(clonePrefab);
                    clone.transform.position = pos;
                    return clone;
                }

                int GetFurthestUnitFrom(int i) {
                    var current = unique[i].transform.position;
                    var furthestIndex = -1;
                    float highestDistance = -1;
                    for (int ch = 0; ch < unique.Count; ch++)
                    {
                        var character = unique[ch];
                        var distanceBetween = (character.transform.position - current).magnitude;
                        if (distanceBetween > highestDistance) {
                            furthestIndex = ch;
                            highestDistance = distanceBetween;
                        }
                    }

                    return furthestIndex;
                }
            }

            transform.position = position;

            keqing.Show();

            movement.CanMove = movement.CanRotate = true;
        }

        public Keqing_E Inject(Keqing keqing) {
            this.keqing = keqing;
            return this;
        }

        private void Awake() {
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

        protected override void Update() {
            base.Update();

            if (!_enabled)
                return;

            if (Input.GetKeyDown(KeyCode.E))
                Cast();
        }
    }
}
