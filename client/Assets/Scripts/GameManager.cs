using System;
using Messages;
using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] new Camera camera;
    [SerializeField] LayerMask planeMask;
    [SerializeField] PositionService positionService;
    [SerializeField] Client client;

    public static int Id { get; private set; }

    private async void Awake()
    {
        Game.MainCamera = camera;
        Game.PlaneMask = planeMask;

        var dispatcher = new Dispatcher();
        dispatcher.Register(MessageType.Hello, (reader, sender) => Id = reader.ReadMessage<HelloFromServer>().id);
        client.Initialize(dispatcher);

        positionService.Initialize(dispatcher, client);
    }

    private void Update()
    {
        Game.Update();
    }

}