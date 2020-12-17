using System;
using UnityEngine;
using UnityEngine.Events;

namespace ClownFiesta.Core {

    [CreateAssetMenu(menuName = "New Character", fileName = "Character")]
    public class CharacterData : ScriptableObject {
        public float MaxHealth;
    }
}
