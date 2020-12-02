using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Core;

namespace ClownFiesta.Characters.Android.Data {

    [CreateAssetMenu(menuName = "Abilities/Android LeftShift", fileName = "LeftShift_Android")]
    public class LeftShift_AndroidAbilityData : AbilityData {
        [Range(0f, 5f)] public float duration;
        [Range(0f, 1f)] public float invincibilityStartTime;
        [Range(0f, 1f)] public float invincibilityEndTime;
    }
}
