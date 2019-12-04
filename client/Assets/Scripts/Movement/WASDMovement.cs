using Animation;
using C_Character;
using C_Services.Input;
using UnityEngine;

namespace Movement
{

    public class WASDMovement : MonoBehaviour, IMovementStrategy
    {
        [SerializeField] float speed;
        [SerializeField] new Rigidbody rigidbody;
        private Vector3 input;
        public IStatus Status { get; private set; }

        private void FixedUpdate()
        {
            if (!Status.CanMove)
                return;

            //  movement
            rigidbody.MovePosition(transform.position + input * speed * Time.deltaTime);
        }

        public void UpdateInput(Vector3 input)
        {
            this.input = input;
        }

        public void Construct(IStatus status, float speed, IInputService input)
        {
            this.Status = status;
            this.speed = speed;

            rigidbody = GetComponent<Rigidbody>();

            GetComponentInChildren<MovementAnimation>().Construct(
                rigidbody, 
                GetComponentInChildren<Animator>(), 
                input
            );
        }
    }
}
