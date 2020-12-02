using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Core {

    public class LinearProjectile : MonoBehaviour {

        public float Range { get; set; }
        public float Speed { get; set; }
        public bool CanMove { get; set; }

        private Rigidbody2D rigidbody;
        public Vector2 Direction {
            get => _direction;
            set => _direction = value.normalized;
        }
        private Vector2 _direction;

        private Coroutine launchCoroutine;

        public event Action<HitEventArgs> Hit;

        private void OnEnable() {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            if (!CanMove)
                return;

            rigidbody.position += _direction * Speed * Time.fixedDeltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var go = other.transform.root.gameObject;
            var entity = go.GetComponent<Entity>();
            if (other != entity.Hurtbox)
                return;

            var e = new HitEventArgs(go, this);
            Hit?.Invoke(e);

            if (e.DestroyProjectile)
                Destroy();
        }

        public void Launch() {
            launchCoroutine = StartCoroutine(_Launch());
        }

        public void Destroy() {
            StopCoroutine(launchCoroutine);
            Destroy(gameObject);
        }

        public virtual bool IsValidTarget(GameObject obj) {
            return true;
        }

        private IEnumerator _Launch() {
            CanMove = true;

            yield return new WaitForSeconds(Range / Speed);

            Destroy(gameObject);
        }
    }

    public class HitEventArgs {
        public bool DestroyProjectile { get; set; } = true;
        public GameObject Target { get; set; }
        public LinearProjectile Projectile { get; set; }

        public HitEventArgs(GameObject target, LinearProjectile projectile) {
            Target = target;
            Projectile = projectile;
        }
    }
}
