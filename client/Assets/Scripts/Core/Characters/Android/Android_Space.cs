using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;

namespace ClownFiesta.Characters.Android {

    public class Android_Space : Ability {

        [Header("Bullet")]
        public GameObject prefab;
        public float speed = 10f;
        public float range = 5f;
        public float damage = 50f;

        public Transform origin;
        private Movement movement;

        public void Cast(Vector2 origin, Vector2 direction) {
            var projectile = Instantiate(prefab).GetComponent<LinearProjectile>();
            projectile.Direction = direction;
            projectile.Speed = speed;
            projectile.Range = range;
            projectile.transform.position = origin;
            projectile.Hit += OnHit;

            projectile.Launch();
        }

        private void OnEnable() {
            if (movement == null)
                movement = GetComponent<Movement>();
        }

        private void Update() {
            if (!_enabled)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
                Cast(new Vector2(origin.position.x, origin.position.y), movement.FacingDirection);
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
    }
}
