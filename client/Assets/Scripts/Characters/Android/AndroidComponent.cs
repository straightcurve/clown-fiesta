using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Characters.Android;

namespace ClownFiesta.Core {

    public class AndroidComponent: Character {
        private void Awake() {
            var ac = new Android(gameObject, data);
            _ac = ac;
        }
    }
}
