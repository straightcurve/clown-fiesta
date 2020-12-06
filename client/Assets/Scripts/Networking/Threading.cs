using System;

using UnityEngine;

namespace ClownFiesta.Networking
{
    public class Threading: MonoBehaviour {

        private static Action queue = null;

        public static void Queue(Action action) {
            queue += action;
        }

        private void Update() {
            if (queue == null)
                return;

            var handle = new Action(queue);
            queue = null;
            handle();
        }

    }
}
