using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ClownFiesta.Core {

    public abstract class Ability : MonoBehaviour {

        [SerializeField]
        protected bool _enabled => InputAction.enabled;

        [ReadOnly]
        [SerializeField]
        protected float _cooldownCounter;

        [ReadOnly]
        [SerializeField]
        protected float cooldown;

        public virtual bool OnCooldown => _cooldownCounter > 0;

        public InputAction InputAction {
            get => inputAction;
            set {
                if (inputAction != null)
                    inputAction.started -= OnButtonPressed;
                
                inputAction = value;
                inputAction.started += OnButtonPressed;
            }
        }
        private InputAction inputAction;

        protected CharacterControls controls;

        public void Enable() => InputAction.Enable();

        public void Disable() => InputAction.Disable();

        public void Cast() {
            if (OnCooldown)
                return;

            _cooldownCounter = cooldown;

            StartCoroutine(_Cast());
        }

        public Ability Inject(CharacterControls controls, InputAction onButtonPressAction) {
            this.controls = controls;
            InputAction = onButtonPressAction;
            return this;
        }

        protected virtual void Update() {
            if (!OnCooldown)
                return;

            _cooldownCounter -= Time.deltaTime;
        }

        protected abstract IEnumerator _Cast();
        protected abstract void OnButtonPressed(InputAction.CallbackContext ctx);
    }
}
