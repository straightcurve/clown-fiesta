using UnityEngine;
using UnityEngine.InputSystem.UI;

namespace ClownFiesta.Core {

    [CreateAssetMenu(menuName = "New/Selectable Character", fileName = "Character")]
    public class SelectableCharacter: ScriptableObject {
        public string characterName;
        public Character characterPrefab;
        public Sprite portrait;
        public GameObject model;
    }
}
