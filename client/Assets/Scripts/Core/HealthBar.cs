using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClownFiesta.Core {

    [System.Serializable]
    public class HealthBar : MonoBehaviour {

        [SerializeField] private Image fill;
        [SerializeField] private Character character;

        private void Start() {
            character.ActualCharacter.Damaged += (OnDamaged);
            OnDamaged(0);
        }

        private void OnDamaged(float amount) {
            UpdateHealth(character.ActualCharacter.Health, character.ActualCharacter.MaxHealth);
        }

        private void UpdateHealth(float current, float max) {
            if (max == 0) {
                fill.fillAmount = 0;
                return;
            }

            fill.fillAmount = current / max;
        }
    }
}
