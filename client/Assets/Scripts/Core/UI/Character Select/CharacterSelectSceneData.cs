using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Core;

namespace ClownFiesta.Core.UI.CharacterSelect {

    [CreateAssetMenu(menuName = "Create Character Select Scene Data", fileName = "CharacterSelectSceneData")]
    public class CharacterSelectSceneData: ScriptableObject {
        public GameObject model;
    }
}
