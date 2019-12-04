using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] float magnitude;

    private void Apply(Rigidbody affected)
    {
        var direction = (affected.position - transform.position).normalized;
        direction.y = 0f;
        affected.AddForce(direction * magnitude, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        var rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody == null)
            return;

        Apply(rigidbody);
    }
}