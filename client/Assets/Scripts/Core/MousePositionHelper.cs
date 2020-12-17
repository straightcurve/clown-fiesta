using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownFiesta.Core {

    public class MousePositionHelper {
        public Vector3 MouseLocation { get; set; }
        public Camera MainCamera { get; set; }
        public LayerMask PlaneMask { get; set; }
        public InputAction MousePositionInputAction { get; set; }

        private Vector3 rawMouseLocation;

        public MousePositionHelper(Camera camera, LayerMask planeMask, InputAction action) {
            MainCamera = camera;
            PlaneMask = planeMask;
            MousePositionInputAction = action;
            MousePositionInputAction.performed += (InputAction.CallbackContext ctx) => {
                rawMouseLocation = ctx.ReadValue<Vector2>();
            };
        }

        public void Update() {
            if (MainCamera != null)
            {
                var ray = MainCamera.ScreenPointToRay(rawMouseLocation);
                if (Physics.Raycast(ray, out var hit, 300f, PlaneMask))
                    MouseLocation = hit.point;
            }
        }
    }
}
