using System;
using System.Collections.Generic;
using C_Services.Input;
using UnityEngine;
using UnityEngine.Events;

namespace Local
{
    public class InputSystem : MonoBehaviour
    {
        //  maps keys to actions
        //  KeyCode.Q --> Action.FlameStrike

        //  subscribers (Champion class?)
        //  maps actions to callbacks
        //  Action.FlameStrike --> () => {}

        readonly protected Dictionary<KeyCode, InputAction> actions = new Dictionary<KeyCode, InputAction>();

        //  from file
        public void LoadSettings() {
            Debug.LogError("Not implemented");
        }

        public void Bind(KeyCode key, InputAction action) {
            if(key == KeyCode.None)
                return;

            if(actions.ContainsKey(key)) actions[key] = action;
            else actions.Add(key, action);
        }

        public void Unbind(KeyCode key) {
            if(actions.ContainsKey(key)) actions.Remove(key);
            else Debug.LogError($"Actions doesnt contain {key}");
        }


        public event Action<Vector3> MovementReceived;
        public event Action<InputAction> InputReceived;

        private void Update()
        {
            var input = Vector3.zero;
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
            MovementReceived?.Invoke(input);

            foreach (var key in actions.Keys)
                if(Input.GetKeyDown(key)) InputReceived?.Invoke(actions[key]);
        }
    }
}
