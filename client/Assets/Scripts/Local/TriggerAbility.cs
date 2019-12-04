using System.Collections;
using Abilities.Abstractions;
using UnityEngine;

namespace Local
{
    public class TriggerAbility : MonoBehaviour
    {
        [SerializeField] Ability ability;
        [SerializeField] float interval = 5f;
        private Coroutine coroutine;
        private WaitForSeconds wait;

        private void Awake()
        {
            if (ability == null)
                ability = GetComponent<Ability>();
            coroutine = StartCoroutine(Trigger());
            wait = new WaitForSeconds(interval);
        }

        private IEnumerator Trigger()
        {
            while (true)
            {
                ability.Cast();
                yield return wait;
            }
        }
    }
}