using UnityEngine;

public class Game
{
    public static Vector3 MouseLocation { get; set; }
    public static Camera MainCamera { get; set; }
    public static LayerMask PlaneMask { get; set; }

    public static void Update()
    {
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