using System.Collections;
using C_Character;
using C_Services.Input;
using UnityEngine;

namespace Movement
{
    public class RandomMovement : MonoBehaviour, IMovementStrategy
    {
        [SerializeField] float moveSpeed;
        [SerializeField] new Rigidbody rigidbody;
        private Vector3 input;
        private Vector3 initial;
        private Vector3 final;

        public IStatus Status { get; private set; }

        public void Construct(IStatus status, float speed, IInputService input)
        {
            this.Status = status;
            this.moveSpeed = speed;
            initial = transform.position;
            final = transform.position + Vector3.left * 5f;

            rigidbody = GetComponent<Rigidbody>();

            StartCoroutine(UpdateInput());
        }

        public void UpdateInput(Vector3 input)
        {
            return; //  not used
        }

        private void FixedUpdate()
        {
            if (!Status.CanMove)
                return;

            //  movement
            rigidbody.MovePosition(transform.position + input * moveSpeed * Time.deltaTime);
        }

        private IEnumerator UpdateInput()
        {
            while (true)
            {
                input = Vector3.left;
                yield return new WaitUntil(() => transform.position.x - final.x < .1f);
                input = Vector3.right;
                yield return new WaitUntil(() => Mathf.Abs(transform.position.x - initial.x) > 5f);
            }
        }
    }
}
