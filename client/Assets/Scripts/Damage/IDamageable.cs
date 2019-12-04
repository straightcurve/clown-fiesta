using System;

namespace Damage
{
    public interface IDamageable
    {
        bool Alive { get; }

        event Action<float> Damaged;

        void Apply(float amount);
        void ApplyOverTime(float amount, float interval, float duration);
    }
}