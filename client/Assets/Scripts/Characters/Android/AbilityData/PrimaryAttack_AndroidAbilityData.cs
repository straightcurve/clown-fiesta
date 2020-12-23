using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Core;

namespace ClownFiesta.Characters.Android.Data {

    [CreateAssetMenu(menuName = "New/Ability Data/Android Primary Attack", fileName = "PrimaryAttack_Android")]
    public class PrimaryAttack_AndroidAbilityData : AbilityData {
        [Range(0f, 2f)] public float duration;
        [Range(0f, 1f)] public float anticipationTime;
        [Range(0f, 1f)] public float returnTime;
        [Range(0f, 1f)] public float slowPercentage;
    }
}
