using Damage;
using UnityEngine;

public class DirectDamageSource : MonoBehaviour
{
    [SerializeField] float amount;
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

        damageable.Apply(amount);

        if (destroyOnContact)
            Destroy(gameObject);
    }
}