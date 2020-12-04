using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Core;

namespace ClownFiesta.Characters.Keqing.Data {

    [CreateAssetMenu(menuName = "Abilities/Keqing Q", fileName = "Q_Keqing")]
    public class Q_KeqingAbilityData : AbilityData {
        [Range(0f, 10f)] public float daggerLifespan = 5f;
        [Range(0f, 1f)] public float spawnDaggerAnticipationTime = .25f;
        [Range(0f, 7f)] public float daggerDamageRadius = 3f;
        [Range(0f, 500f)] public float damage = 50f;
    }
}
