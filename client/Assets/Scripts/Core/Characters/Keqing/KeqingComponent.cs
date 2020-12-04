using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Characters.Keqing;

namespace ClownFiesta.Core {

    public class KeqingComponent: Character {
        private void Awake() {
            var ac = new Keqing();
            ac.Inject(gameObject)
            .Inject(data);

            _ac = ac;
        }
    }
}
