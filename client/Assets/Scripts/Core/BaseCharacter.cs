using System;
using UnityEngine;

namespace ClownFiesta.Core {

    [Serializable]
    public class BaseCharacter : ICharacter {

        public int Level => _level;
        [SerializeField] protected int _level;

        public float Health => _health;
        [SerializeField] protected float _health;

        public float MaxHealth => _maxHealth;
        [SerializeField] protected float _maxHealth;

        public bool Alive => Health > 0f;


        public event Action<float> Damaged;
        public event Action<ICharacter> Died;

        public void RestoreFullHealth() {
            _health = MaxHealth;
        }

        public virtual void TakeDamage(float amount) {
            if (!Alive)
                return;

            _health -= amount;

            Damaged?.Invoke(amount);

            if (!Alive) {
                OnDeath();
                Died?.Invoke(this);
            }
        }

        protected virtual void OnDeath() { }
    }
}
