using Abilities;
using C_Character;
using C_Services.Input;
using Helpers;
using Local;
using Movement;
using UnityEngine;

public class LocalGameManager : MonoBehaviour
{

    [SerializeField] new Camera camera;
    [SerializeField] LayerMask planeMask;
    IInputService inputService;
    [SerializeField] GameObject player;

    private void Awake()
    {
        Game.MainCamera = camera;
        Game.PlaneMask = planeMask;

        var modelPath = Resources.Load<SharedData>("SharedData").lockedInModelPath;
        var modelPrefab = Resources.Load<GameObject>(modelPath);
        var model = Instantiate(modelPrefab, player.transform);
        model.transform.localScale = Vector3.one * 2f;

        var champion = player.GetComponent<IChampion>();
        var status = new Status();
        status.Enter(new NormalState());
        inputService = new InputService();
        champion.Construct(inputService, status, player.GetComponent<IMovementStrategy>(), 10);
    }

    private void Update()
    {
        Game.Update();
        inputService.Update();
    }

}