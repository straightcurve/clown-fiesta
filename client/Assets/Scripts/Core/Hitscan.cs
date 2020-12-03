using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Core {

    public class Hitscan : MonoBehaviour {

        public Collider2D collider;

        public void Activate() => collider.enabled = true;
        public void Deactivate() => collider.enabled = false;

        public bool IsActive => collider.enabled;
    }
}
