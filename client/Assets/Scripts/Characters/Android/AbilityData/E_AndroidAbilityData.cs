using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Core;

namespace ClownFiesta.Characters.Android.Data {

    [CreateAssetMenu(menuName = "Abilities/Android E", fileName = "E_Android")]
    public class E_AndroidAbilityData : AbilityData {
        [Range(0f, 2f)] public float duration;
        [Range(0f, 1f)] public float anticipationTime;
        [Range(0f, 1f)] public float returnTime;
    }
}
