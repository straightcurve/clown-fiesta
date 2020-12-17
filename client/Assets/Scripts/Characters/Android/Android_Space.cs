using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;
using ClownFiesta.Characters.Android.Data;
using UnityEngine.InputSystem;

namespace ClownFiesta.Characters.Android {

    public class Android_Space : Ability {

        [SerializeField] protected Space_AndroidAbilityData data;

        [Header("Bullet")]
        public GameObject prefab;
        public float speed = 10f;
        public float range = 5f;
        public float damage = 50f;

        public Transform origin;
        private Movement movement;

        private void Awake() {
            if (data == null) {
                Debug.LogError("data not set");
                return;
            }

            cooldown = data.Cooldown;
        }

        protected override IEnumerator _Cast() {
            var projectile = Instantiate(prefab).GetComponent<LinearProjectile>();
            projectile.Direction = movement.FacingDirection;
            projectile.Speed = speed;
            projectile.Range = range;
            projectile.transform.position = new Vector2(origin.position.x, origin.position.y);
            projectile.Hit += OnHit;

            projectile.Launch();

            yield return null;
        }

        private void Start() {
            if (movement == null)
                movement = GetComponent<Movement>();
        }

        private void OnHit(HitEventArgs args) {
            var obj = args.Target;
            var by = args.Projectile;
            var character = obj.GetComponent<Character>();
            if (character == null) return;
            if (!character.ActualCharacter.Alive) {
                args.DestroyProjectile = false;
                return;
            }

            character.TakeDamage(damage);
        }

        protected override void OnButtonPressed(InputAction.CallbackContext ctx) {
            Cast();
        }
    }
}
