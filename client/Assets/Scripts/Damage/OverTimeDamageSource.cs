using Damage;
using UnityEngine;

public class OverTimeDamageSource : MonoBehaviour
{
    [SerializeField] float amount = 5f;
    [SerializeField] float interval = 1f;
    [SerializeField] float duration = 4f;
    [SerializeField] bool destroyOnContact = true;

    /// <summary>
    ///     Set this through code whenever we instantiate
    /// an object that has this component.
    /// </summary>
    /// <param name="other"></param>
    [HideInInspector] public GameObject source;
    [SerializeField] bool affectsSource;

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable == null)
            return;
        if (!damageable.Alive)
            return;

        //  TODO: use something else
        if (other.gameObject.name == (source.name) && !affectsSource)
            return;

        damageable.ApplyOverTime(amount, interval, duration);

        if (destroyOnContact)
            Destroy(gameObject);
    }
}