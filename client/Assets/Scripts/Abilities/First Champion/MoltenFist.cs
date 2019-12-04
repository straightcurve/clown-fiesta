using System;
using System.Collections;
using Abilities.Abstractions;
using Movement;
using UnityEngine;

namespace Abilities
{
    /// <summary>
    ///     Dash forward, knock back enemies and slow them
    /// </summary>
    public class MoltenFist : Ability
    {
        [Header("Ability-specific params")]
        [SerializeField] float time = 1f;
        [SerializeField] new Rigidbody rigidbody;

        protected override IEnumerator CastAbility()
        {
            var location = Game.MouseLocation;
            var initial = transform.position;
            location.y = initial.y;

            //  turn off movement
            GetComponent<WASDMovement>().enabled = false;

            //  move to location with high speed
            // while (Vector3.Distance(transform.position, location) > .5f)
            // {
            //     rigidbody.MovePosition(transform.position + direction.normalized * dashSpeed * Time.deltaTime);
            //     yield return null;
            // }

            //  kinematic body and calculate xz displacement??
            rigidbody.isKinematic = true;
            var force = GetDashForce(initial, location);
            while (Vector3.Distance(transform.position, location) > .5f)
            {
                rigidbody.MovePosition(transform.position + force * Time.deltaTime);
                yield return null;
            }

            GetComponent<WASDMovement>().enabled = true;
        }

        private Vector3 GetDashForce(Vector3 from, Vector3 to)
        {
            var xz = to - from;
            var forceXZ = xz / time;
            forceXZ.y = 0;
            return forceXZ;
        }
    }
}