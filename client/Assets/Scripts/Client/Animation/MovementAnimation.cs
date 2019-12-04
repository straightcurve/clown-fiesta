using C_Services.Input;
using Movement;
using UnityEngine;

namespace Animation
{
    public class MovementAnimation : MonoBehaviour
    {
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] Animator animator;
        private Vector3 previousPosition;
        private Strafing strafing;

        public void Construct(
            Rigidbody rigidbody, 
            Animator animator, 
            IInputService input)
        {
            this.rigidbody = rigidbody;
            this.animator = animator;
            strafing = new Strafing();

            input.MovementReceived += (i) => {
                strafingValue = strafing.Get(i, transform.parent);
            };
        }

        [SerializeField] private float strafingValue;

        private void Update()
        {
            if (previousPosition != transform.parent.position)
            {
                animator.SetFloat("velocity", 1);
                animator.SetFloat("strafing", strafingValue);
            }
            else
            {
                animator.SetFloat("velocity", 0);
                animator.SetFloat("strafing", 0);
            }
            previousPosition = transform.parent.position;
        }
    }
}