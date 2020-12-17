using UnityEngine;

namespace ClownFiesta.Core {

    public class Game : MonoBehaviour
    {
        public static Vector3 MouseLocation;
        public Camera MainCamera;
        public LayerMask PlaneMask;

        private void Update()
        {
            return;

            if (MainCamera != null)
            {
                var ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, 300f, PlaneMask))
                {
                    MouseLocation = hit.point;
                }
            }
        }
    }
}
