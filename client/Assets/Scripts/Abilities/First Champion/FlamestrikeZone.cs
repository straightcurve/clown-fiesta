using System.Collections.Generic;
using C_Character;
using UnityEngine;

namespace Abilities
{
    public class FlamestrikeZone : MonoBehaviour
    {
        private bool activated;

        [SerializeField] float damage = 20f;
        [SerializeField] float stunDuration = .6f;
        [SerializeField] float radius = 3f;
        [SerializeField] LayerMask affectedLayers;
        [SerializeField] GameObject particles;
        private List<ParticleSystem> list;

        private void Awake()
        {
            list = new List<ParticleSystem>();
            particles.transform.GetComponentsInChildren<ParticleSystem>(list);
        }

        public void Activate()
        {
            activated = true;
            particles.SetActive(true);

            var results = Physics.SphereCastAll(transform.position, radius, transform.position, 1f, affectedLayers);
            foreach (var hit in results)
            {
                var champion = hit.transform.GetComponent<IChampion>();
                if (champion == null)
                    continue;

                if (!champion.Alive)
                    continue;

                champion.Apply(damage);
                champion.Apply(StateType.Stunned, stunDuration);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}