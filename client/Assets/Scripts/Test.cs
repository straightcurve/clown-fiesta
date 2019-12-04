using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    // private Dictionary<Guid, NetObject> objects = new Dictionary<Guid, NetObject>();
    private HubConnection conn;

    private async void Start()
    {
        // conn = await NetworkManager.GetAsync("game");
        conn.On<Guid>("SetId", (id) =>
        {
            print($"{id}");
            // var netObj = Instantiate(prefab).GetComponent<NetObject>();
            // netObj.Initialize(id);
            // objects.Add(id, netObj);
        });

        conn.On<List<Guid>, List<V3>>("Positions", (Ids, Vectors) =>
        {
            print($"receiving ({Vectors[0].x}, {Vectors[0].y}, {Vectors[0].z})");
            for (int p = 0; p < Ids.Count; p++)
            {
                // objects[Ids[p]].transform.position =
                // new Vector3(
                //     Vectors[p].x,
                //     Vectors[p].y,
                //     Vectors[p].z
                // );
            }
        });

        // conn.On<Positions>("Positions", (positions) =>
        // {
        //     print($"{positions.Vectors[0].x}");
        //     for (int p = 0; p < positions.Ids.Count; p++)
        //     {
        //         objects[positions.Ids[p]].transform.position =
        //             new Vector3(
        //                 positions.Vectors[p].x,
        //                 positions.Vectors[p].y,
        //                 positions.Vectors[p].z
        //             );
        //     }
        // });
        // conn.On<string>("TestResponse", TestResponse);
        // conn.InvokeAsync("TestInvoke", "test");

    }

    private void TestResponse(string response)
    {
        print(response);
    }

    private void OnDestroy()
    {
        // NetworkManager.Remove("game");
    }
}

// public struct Positions
// {
//     public List<Guid> Ids { get; set; }
//     public List<V3> Vectors { get; set; }
// }

public struct V3
{
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }
}

public static class Extensions
{
    public static Vector3 ToVector3(this V3 v)
    {
        return new Vector3() { x = v.x, y = v.y, z = v.z };
    }

    public static V3 ToV3(this Vector3 v)
    {
        return new V3() { x = v.x, y = v.y, z = v.z };
    }
}