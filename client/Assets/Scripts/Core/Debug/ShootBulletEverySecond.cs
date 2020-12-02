using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Core.Abilities {

    public class ShootBulletEverySecond : MonoBehaviour {

        [Header("Bullet")]
        public GameObject prefab;
        public float speed = 10f;
        public float range = 5f;
        public float damage = 50f;

        public Transform origin;

        public void Cast(Vector2 origin, Vector2 direction) {
            var projectile = Instantiate(prefab).GetComponent<LinearProjectile>();
            projectile.Direction = direction;
            projectile.Speed = speed;
            projectile.Range = range;
            projectile.transform.position = origin;
            projectile.Hit += OnHit;

            projectile.Launch();
        }

        private Coroutine castCoroutine;
        private void Start() {
            castCoroutine = StartCoroutine(_Cast());
        }

        private void OnApplicationQuit() {
            if (castCoroutine == null)
                return;

            StopCoroutine(castCoroutine);
        }

        private IEnumerator _Cast() {
            while (true) {
                Cast(new Vector2(origin.position.x, origin.position.y), Vector2.up * -1);
                yield return new WaitForSeconds(1f);
            }
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
