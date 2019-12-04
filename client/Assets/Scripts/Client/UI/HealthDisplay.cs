using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] Image fill;
        IChampion champion;

        private void Awake()
        {
            Construct(GetComponentInParent<IChampion>());
        }

        private void OnDestroy()
        {
            champion.Damaged -= OnDamaged;
        }

        public void Construct(IChampion champion)
        {
            this.champion = champion;
            champion.Damaged += OnDamaged;

            OnDamaged(0f);
        }

        private void OnDamaged(float amount)
        {
            // PopupTextHelper.Spawn(transform.parent, transform.position, $"-{amount}");
            fill.fillAmount = champion.Health / champion.MaxHealth;
        }
    }
}
