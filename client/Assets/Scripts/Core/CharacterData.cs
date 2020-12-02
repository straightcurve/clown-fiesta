using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Characters.Android;

namespace ClownFiesta.Core {

    [CreateAssetMenu(menuName = "New Character", fileName = "Character")]
    public class CharacterData : ScriptableObject {
        public float MaxHealth;
    }
}
