using UnityEngine;

namespace Abilities
{
    public class Projectile : MonoBehaviour
    {

        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] GameObject particles;

        private void Awake()
        {
            if (particles == null)
            {
                Debug.LogError("Particles not set!");
            }
        }

        public void AddForce(Vector3 direction, float magnitude)
        {
            rigidbody.AddForce(direction * magnitude, ForceMode.Impulse);
            if (particles != null)
                particles.SetActive(true);
        }
    }
}