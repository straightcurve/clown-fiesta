using System;
using System.Collections;
using UnityEngine;

namespace Movement
{
    public class Strafing
    {
        public float Get(Vector3 input, Transform facing)
        {
            var computed = Vector3.zero;
            var i = facing.forward;
            var j = facing.right;
            computed.z = input.x * i.z + input.z * i.x;
            computed.x = input.x * j.z + input.z * j.x;
            // Debug.Log($"i: {i}  j: {j}  || strafing: {computed.x}");

            return computed.x;
        }
    }
}
