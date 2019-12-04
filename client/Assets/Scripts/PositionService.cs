using System;
using System.Collections.Generic;
using Messages;
using Microsoft.AspNetCore.SignalR.Client;
using Movement;
using UnityEngine;
using UnityEngine.Networking;

public class PositionService : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    // [SerializeField] KeyBindings keyBindings;
    private Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>();

    public void Initialize(Dispatcher dispatcher, IClient client)
    {
        dispatcher.Register(MessageType.Movement, (reader, sender) =>
        {
            var message = reader.ReadMessage<Positions>();
            for (int p = 0; p < message.ids.Count; p++)
            {
                if (objects.ContainsKey(message.ids[p]))
                {
                    objects[message.ids[p]].transform.position =
                        new Vector3(
                            message.positions[p].x,
                            message.positions[p].y,
                            message.positions[p].z
                        );
                }
                else
                {
                    var netObj = Instantiate(prefab);
                    objects.Add(message.ids[p], netObj);
                    if (message.ids[p] == GameManager.Id)
                    {
                        // var movement = netObj.AddComponent<NetWASDMovement>();
                        // movement.Initialize(message.ids[p], keyBindings, client);
                    }
                    else
                    {
                        print($"message: {message.ids[p]} manager: {GameManager.Id}");
                    }
                }
            }
        });
    }
}