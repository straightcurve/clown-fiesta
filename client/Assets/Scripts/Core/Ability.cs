using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ClownFiesta.Core {

    public abstract class Ability : MonoBehaviour {

        [SerializeField]
        protected bool _enabled = true;

        [ReadOnly]
        [SerializeField]
        protected float _cooldownCounter;

        [ReadOnly]
        [SerializeField]
        protected float cooldown;

        public virtual bool OnCooldown => _cooldownCounter > 0;

        public void Enable() {
            _enabled = true;
        }

        public void Disable() {
            _enabled = false;
        }

        public void Cast() {
            if (OnCooldown)
                return;

            print("casted");

            _cooldownCounter = cooldown;

            StartCoroutine(_Cast());
        }

        protected virtual void Update() {
            if (!OnCooldown)
                return;

            _cooldownCounter -= Time.deltaTime;
        }

        protected abstract IEnumerator _Cast();
    }
}
