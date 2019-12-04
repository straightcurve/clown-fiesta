using System;
using UnityEngine;

namespace Movement
{
    public class MouseMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
        [SerializeField] new Rigidbody rigidbody;
        private Vector3 destination;
        private bool move;

        private void FixedUpdate()
        {
            if (!move)
                return;

            var moveVector = destination - transform.position;
            moveVector.y = 0f;

            if (moveVector.magnitude < .1f)
            {
                move = false;
                return;
            }

            var normalized = moveVector.normalized;

            //  movement
            rigidbody.MovePosition(transform.position + normalized * moveSpeed * Time.deltaTime);
        }

        public void Move()
        {
            destination = Game.MouseLocation;
            move = true;
        }
    }
}
