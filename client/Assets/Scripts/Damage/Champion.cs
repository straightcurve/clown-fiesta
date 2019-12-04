using System;
using System.Collections;
using System.Collections.Generic;
using Abilities.Abstractions;
using Animation;
using C_Character;
using C_Services.Input;
using Local;
using Movement;
using UnityEngine;

public class Champion : MonoBehaviour, IChampion
{
    [SerializeField] float health = 1000f;

    public bool Alive => health > 0;
    public float Health => health;
    public float MaxHealth { get; private set; }


    public event Action<float> Damaged;

    private Coroutine ccCoroutine;


    public void Construct(
        IInputService input, 
        IStatus status, 
        IMovementStrategy movement,
        float moveSpeed)
    {
        MaxHealth = health;

        InitMovement(movement, status, moveSpeed, input);
        InitCasting();
        InitInputHandlers(input);
        InitStatus(status);
    }

    public void Apply(float amount)
    {
        health -= amount;

        Damaged?.Invoke(amount);

        if (!Alive) print($"{name} died.");
    }

    public void ApplyOverTime(float amount, float interval, float duration)
    {
        StartCoroutine(ApplyOverTime_Coroutine(amount, interval, duration));
    }

    private IEnumerator ApplyOverTime_Coroutine(float amount, float interval, float duration)
    {
        var wait = new WaitForSeconds(interval);
        do
        {
            Apply(amount);
            yield return wait;
            duration -= interval;
        } while (duration > 0);
    }

    #region Movement

    private IMovementStrategy movement;

    private void InitMovement(
        IMovementStrategy movement, 
        IStatus status, 
        float speed,
        IInputService input) 
    {
        this.movement = movement;
        movement.Construct(status, speed, input);
    }

    #endregion

    #region Casting

    public List<Ability> Abilities { get; private set; } = new List<Ability>();
    public void TryCast(Ability ability)
    {
        //  are we able to cast abilities?
        if(!status.CanCast) return;

        ability.Cast();
    }

    public void InitCasting() {
        GetComponents<Ability>(Abilities);
    }

    #endregion

    #region Input handling
    readonly protected Dictionary<InputAction, Action> handlers = new Dictionary<InputAction, Action>();

    private void InitInputHandlers(IInputService service) {
        Abilities.ForEach(ability => {
            service.Bind(ability.Key, ability.Action);
        });

        for (int a = 0; a < Abilities.Count; a++) {
            if(Abilities[a].Action == InputAction.None) continue;
            
            int cache = a;
            handlers.Add(Abilities[a].Action, () => {
                TryCast(Abilities[cache]);
            });
        }

        service.InputReceived += (action) => {
            handlers[action]();
        };

        service.MovementReceived += movement.UpdateInput;
    }
    #endregion

    #region Status
    private IStatus status;
    public StateType State => status.Type;

    private void InitStatus(IStatus status) {
        this.status = status;
    }

    public void Apply(StateType state, float duration)
    {
        switch(state) {
            case StateType.Rooted:
                status.Enter(new RootedState());
                break;
            case StateType.Silenced:
                status.Enter(new SilencedState());
                break;
            case StateType.Stunned:
                status.Enter(new StunnedState());
                break;
            default:
                status.Enter(new NormalState());
                break;
        }

        if (ccCoroutine != null)
            StopCoroutine(ccCoroutine);

        ccCoroutine = StartCoroutine(ResetState(duration));
    }

    private IEnumerator ResetState(float duration)
    {
        yield return new WaitForSeconds(duration);
        status.Enter(new NormalState());
        ccCoroutine = null;
    }

    #endregion
}