using System.Collections;
using Abilities.Abstractions;
using UnityEngine;

namespace Abilities
{
    /// <summary>
    ///     Launches a projectile
    /// </summary>
    public class Fireball : Ability
    {
        [Header("Ability-specific params")]
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float launchMagnitude = 10f;
        [SerializeField] float lifetime = 2f;

        protected override IEnumerator CastAbility()
        {
            Launch();
            return null;
        }

        private void Launch()
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.GetComponent<DirectDamageSource>().source = this.gameObject;
            projectile.GetComponent<OverTimeDamageSource>().source = this.gameObject;
            projectile.AddForce(transform.forward, launchMagnitude);
            Destroy(projectile.gameObject, lifetime);
        }
    }
}