using System;
using UnityEngine;
using UnityEngine.Events;

using ClownFiesta.Characters.Grunt;

namespace ClownFiesta.Core {

    public class GruntComponent: Character {
        private void Awake() {
            var ac = new Grunt();
            ac.Inject(gameObject)
            .Inject(data);

            _ac = ac;
        }
    }
}
