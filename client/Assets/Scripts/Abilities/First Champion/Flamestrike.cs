using System.Collections;
using Abilities.Abstractions;
using UnityEngine;

namespace Abilities
{
    /// <summary>
    ///     Creates a zone that damages and stuns enemies after a delay
    /// </summary>
    public class Flamestrike : Ability
    {
        [Header("Ability-specific params")]
        [SerializeField] GameObject prefab;
        [SerializeField] float lifetimeAfterActivation = 1f;
        [SerializeField] float delay = 1f;
        [SerializeField] float yLocation = .6f;


        protected override IEnumerator CastAbility()
        {
            var location = Game.MouseLocation;
            location.y = yLocation;
            var zone = Instantiate(prefab, location, Quaternion.identity).GetComponent<FlamestrikeZone>();

            yield return new WaitForSeconds(delay);

            zone.Activate();

            yield return new WaitForSeconds(lifetimeAfterActivation);

            Destroy(zone.gameObject);
        }
    }
}