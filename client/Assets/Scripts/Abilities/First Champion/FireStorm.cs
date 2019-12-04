using System.Collections;
using Abilities.Abstractions;
using UnityEngine;

namespace Abilities
{
    /// <summary>
    ///     Channels and then launches a number of projectiles in quick succession
    /// </summary>
    public class FireStorm : Ability
    {
        [Header("Ability-specific params")]
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float launchMagnitude = 10f;
        [SerializeField] float lifetime = 2f;
        [SerializeField] float delayBetweenProjectileLaunch = .25f;

        private WaitForSeconds wait;

        private void Awake()
        {
            wait = new WaitForSeconds(delayBetweenProjectileLaunch);
        }

        protected override IEnumerator CastAbility()
        {
            Launch();
            yield return wait;
            Launch();
            yield return wait;
            Launch();
        }

        private void Launch()
        {
            var projectile = Instantiate(projectilePrefab, transform.position + transform.forward * 2f, Quaternion.identity).GetComponent<Projectile>();
            projectile.GetComponent<DirectDamageSource>().source = this.gameObject;
            projectile.GetComponent<OverTimeDamageSource>().source = this.gameObject;
            projectile.AddForce(transform.forward, launchMagnitude);
            Destroy(projectile.gameObject, lifetime);
        }
    }
}