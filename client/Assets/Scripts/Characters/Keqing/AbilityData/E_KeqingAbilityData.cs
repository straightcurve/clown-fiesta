using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Core;

namespace ClownFiesta.Characters.Keqing.Data {

    [CreateAssetMenu(menuName = "Abilities/Keqing E", fileName = "E_Keqing")]
    public class E_KeqingAbilityData : AbilityData {
        [Range(0f, 10f)] public float radius = 5f;
        [Range(0f, 500f)] public float damage = 20f;
        [Range(0f, 2500f)] public float finalSlashDamage = 100f;
        [Range(0f, 1f)] public float delayBetweenSlashes = 1f;
        [Range(0f, 2f)] public float distanceBehindTarget = 2f;
        [Range(0f, 2f)] public float cloneFadeOut = .5f;
        public GameObject clonePrefab;

        public UnityEngine.Color lineColor;
    }
}
