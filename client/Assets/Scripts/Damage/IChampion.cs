using System.Collections.Generic;
using Abilities.Abstractions;
using C_Character;
using C_Services.Input;
using Damage;
using Movement;

public interface IChampion : IDamageable
{
    float Health { get; }
    float MaxHealth { get; }

    #region Status
    StateType State { get; }
    void Apply(StateType state, float duration);
    #endregion

    #region Casting
    List<Ability> Abilities { get; }
    void TryCast(Ability ability);
    #endregion

    void Construct(
        IInputService input, 
        IStatus status, 
        IMovementStrategy movement,
        float moveSpeed
    );
}
