using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;
using ClownFiesta.Core.Movement;
using ClownFiesta.Characters.Keqing.Data;

namespace ClownFiesta.Characters.Keqing {

    public class Keqing_Clone : MonoBehaviour {

        [SerializeField] protected E_KeqingAbilityData data;
        protected readonly List<SpriteRenderer> renderers = new List<SpriteRenderer>();
        
        private Coroutine coroutine;

        private void Start() {
            GetComponentsInChildren<SpriteRenderer>(renderers);
            Fade();
        }

        public void Fade() {
            if (coroutine != null)
                return;

            coroutine = StartCoroutine(_Fade());
        }

        private IEnumerator _Fade() {

            var duration = data.cloneFadeOut;
            while (duration > 0f) {
                duration -= Time.deltaTime;

                renderers.ForEach(renderer => {
                    var color = renderer.color;
                    color.a = duration / data.cloneFadeOut;
                    renderer.color = color;
                });

                yield return null;
            }

            StopCoroutine(coroutine);

            Destroy(gameObject);
        }
    }
}
