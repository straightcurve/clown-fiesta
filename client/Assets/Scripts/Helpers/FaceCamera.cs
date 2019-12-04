using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public class FaceCamera : MonoBehaviour
    {
        Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void LateUpdate()
        {
            var dir = camera.transform.position - transform.position;
            var angle = Vector3.Angle(camera.transform.position, transform.position);
            transform.rotation = Quaternion.Euler(angle, 0, 0);
        }
    }
}
