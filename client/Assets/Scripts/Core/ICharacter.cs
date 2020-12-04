using System;
using UnityEngine;

namespace ClownFiesta.Core {

    public interface ICharacter {
        bool Alive { get; }
        float Health { get; }
        float MaxHealth { get; }

        event Action<float> Damaged;
        event Action<ICharacter> Died;

        void TakeDamage(float amount);
    }
}
