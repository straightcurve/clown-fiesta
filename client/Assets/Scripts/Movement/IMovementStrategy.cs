using C_Character;
using C_Services.Input;
using UnityEngine;

namespace Movement
{
    public interface IMovementStrategy
    {
        IStatus Status { get; }

        void Construct(IStatus status, float speed, IInputService input);
        void UpdateInput(Vector3 input);
    }
}
