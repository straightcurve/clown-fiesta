using System.Collections;
using C_Services.Input;
using UnityEngine;

namespace Abilities.Abstractions
{
    [RequireComponent(typeof(Champion))]
    public abstract class Ability : MonoBehaviour
    {
        [SerializeField] protected KeyCode key = KeyCode.None;
        [SerializeField] protected InputAction action = InputAction.None;
        [SerializeField] protected int mouseButton = -1;
        [SerializeField] protected float cooldown = 3f;
        [SerializeField] protected float castTime = .5f;
        private float cooldownCounter;
        private bool castable = true;

        public KeyCode Key => key;
        public InputAction Action => action;
        public int MouseButton => mouseButton;


        public void Cast()
        {
            if (!castable)
                return;

            castable = false;

            StartCoroutine(Cast_Coroutine());
        }

        protected abstract IEnumerator CastAbility();

        private IEnumerator Cast_Coroutine()
        {
            yield return new WaitForSeconds(castTime);

            yield return CastAbility();

            cooldownCounter = cooldown;
        }

        private void Update()
        {
            if (cooldownCounter <= 0)
                return;

            cooldownCounter -= Time.deltaTime;
            if (cooldownCounter <= 0)
                castable = true;
        }
    }
}