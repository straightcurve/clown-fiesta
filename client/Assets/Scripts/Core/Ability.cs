using System;
using UnityEngine;
using UnityEngine.Events;

namespace ClownFiesta.Core {

    public class Ability : MonoBehaviour {

        protected bool _enabled = true;

        public void Enable() {
            _enabled = true;
        }

        public void Disable() {
            _enabled = false;
        }
    }
}
