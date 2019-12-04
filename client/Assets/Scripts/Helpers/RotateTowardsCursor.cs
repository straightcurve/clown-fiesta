using UnityEngine;

namespace Helpers
{
    public class RotateTowardsCursor : MonoBehaviour
    {
        private void Update()
        {
            var moveVector = Game.MouseLocation - transform.position;
            moveVector.y = 0f;
            transform.forward = moveVector.normalized;
        }
    }
}
