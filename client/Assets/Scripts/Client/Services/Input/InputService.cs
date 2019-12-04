using System;
using System.Collections.Generic;
using UnityEngine;

namespace C_Services.Input
{
    public interface IInputService
    {
        event Action<Vector3> MovementReceived;
        event Action<InputAction> InputReceived;

        void Bind(KeyCode key, InputAction action);
        void LoadSettings();
        void Unbind(KeyCode key);
        void Update();
    }

    public class InputService : IInputService
    {
        //  maps keys to actions
        //  KeyCode.Q --> Action.FlameStrike

        //  subscribers (Champion class?)
        //  maps actions to callbacks
        //  Action.FlameStrike --> () => {}

        readonly protected Dictionary<KeyCode, InputAction> actions = new Dictionary<KeyCode, InputAction>();

        public event Action<Vector3> MovementReceived;
        public event Action<InputAction> InputReceived;

        //  from file
        public void LoadSettings()
        {
            Debug.LogError("Not implemented");
        }

        public void Bind(KeyCode key, InputAction action)
        {
            if (key == KeyCode.None)
                return;

            if (actions.ContainsKey(key)) actions[key] = action;
            else actions.Add(key, action);
        }

        public void Unbind(KeyCode key)
        {
            if (actions.ContainsKey(key)) actions.Remove(key);
            else Debug.LogError($"Actions doesnt contain {key}");
        }

        public void Update()
        {
            var input = Vector3.zero;
            input.x = UnityEngine.Input.GetAxis("Horizontal");
            input.z = UnityEngine.Input.GetAxis("Vertical");
            MovementReceived?.Invoke(input);

            foreach (var key in actions.Keys)
                if (UnityEngine.Input.GetKeyDown(key)) InputReceived?.Invoke(actions[key]);
        }
    }
}