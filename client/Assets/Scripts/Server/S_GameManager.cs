using S_Services;
using UnityEngine;

namespace S_
{
    public class S_GameManager : MonoBehaviour
    {
        [SerializeField] S_PositionService positionService;
        [SerializeField] Server server;

        private void Awake()
        {
            var dispatcher = new Dispatcher();
            positionService.Initialize(dispatcher, server);
            server.Initialize(dispatcher);
        }

    }
}