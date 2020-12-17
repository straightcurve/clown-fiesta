using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;
using ClownFiesta.Characters.Keqing.Data;
using UnityEngine.InputSystem;

namespace ClownFiesta.Characters.Keqing {

    public class Keqing_Q : Ability {

        [SerializeField] protected Q_KeqingAbilityData data;

        public GameObject daggerPrefab;

        private Movement movement;
        private Animator animator;

        private readonly List<Character> unique = new List<Character>();

        protected override IEnumerator _Cast() {
            //  spawn dagger at mouse location
            //  if key pressed again
            //  teleport to dagger
            //  deal aoe damage

            var dagger = Instantiate(daggerPrefab);
            dagger.transform.position = ClownFiesta.Core.Game.MouseLocation;

            animator.SetTrigger("Q_Spawn_Dagger");

            var daggerLifespan = data.daggerLifespan;
            var spawnDaggerAnticipationTime = data.spawnDaggerAnticipationTime;
            var shouldTeleport = false;
            while (daggerLifespan > 0f) {
                daggerLifespan -= Time.deltaTime;

                if (data.daggerLifespan - daggerLifespan > spawnDaggerAnticipationTime) {
                    shouldTeleport = Input.GetKeyDown(KeyCode.Q);
                    if (shouldTeleport)
                        break;
                }

                yield return null;
            }

            var daggerPosition = dagger.transform.position;
            Destroy(dagger.gameObject);

            if (shouldTeleport) {
                transform.position = daggerPosition;

                var radius = data.daggerDamageRadius;

                //  TODO: Layermask
                var targets = Physics2D.OverlapCircleAll(daggerPosition, radius);
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

                    var damage = data.damage;
                    foreach (var character in unique)
                        character.TakeDamage(damage);
                    
                    unique.Clear();
                }
            }
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

            cooldown = data.Cooldown;
            // animator.SetFloat("Q_AnimationSpeed", 1 / data.duration);
        }

        public void OnButtonPressed(InputAction.CallbackContext ctx) {
            if (!_enabled)
                return;

            Cast();
        }
    }
}
