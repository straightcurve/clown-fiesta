using System;
using System.Collections;
using Abilities.Abstractions;
using UnityEngine;

namespace Abilities
{
    /// <summary>
    ///     Jumps to a target location and deals damage after landing
    /// </summary>
    public class SearingFlight : Ability
    {
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] float duration = 1f;
        [SerializeField] AnimationCurve curve;
        [SerializeField] float peakHeight = 2f;

        protected override IEnumerator CastAbility()
        {
            var location = Game.MouseLocation;
            var initial = transform.position;
            location.y = initial.y;

            var force = GetJumpForce(initial, location);
            rigidbody.AddForce(force, ForceMode.VelocityChange);
            Debug.DrawLine(initial, location, Color.red, 10f);

            return null;
        }

        private void OnCollisionEnter(Collision collision)
        {
            rigidbody.velocity = Vector3.zero;
        }

        private Vector3 GetVelocity(Vector3 initial, Vector3 target, float time)
        {
            var distance = target - initial;
            var distanceXZ = distance;
            distanceXZ.y = initial.y;

            var vxz = distanceXZ.magnitude / time;
            // var vy = peakHeight * time + .5f * Gravity * Mathf.Pow(time, 2);
            var vy = ((peakHeight - initial.y) - .5f * Mathf.Abs(Physics.gravity.y) * Mathf.Pow(time, 2)) / time;
            // var vy = Mathf.Sqrt(2 * Gravity * peakHeight);
            // var vy = Mathf.Abs(Physics.gravity.y) * time * time + time + peakHeight;

            var velocity = distanceXZ.normalized * vxz;
            Debug.DrawLine(initial, velocity, Color.red, 30f);
            Debug.DrawLine(target, velocity, Color.magenta, 30f);
            velocity.y = vy;
            Debug.DrawLine(initial, velocity, Color.green, 30f);
            Debug.DrawLine(target, velocity, Color.blue, 30f);
            return velocity;
        }

        private Vector3 GetJumpForce(Vector3 from, Vector3 to)
        {
            var xz = to - from;
            var forceXZ = xz / duration;
            forceXZ.y = (float)Math.Sqrt(-2 * Physics.gravity.y * peakHeight);
            return forceXZ;
        }
    }
}