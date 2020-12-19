using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace ClownFiesta.Core {

    public class ControlPoint: MonoBehaviour {

        public float team1Progress;
        public float team2Progress;

        public float scaling = 5f;
        public float maxProgress = 100f;

        public float radius = 10f;
        public LayerMask mask;

        [SerializeField] private Image team1ProgressImage;
        [SerializeField] private Image team2ProgressImage;

        private readonly Collider2D[] hitObjects = new Collider2D[16];
        private readonly List<Character> unique = new List<Character>();

        private void Update() {
            unique.Clear();

            var count = PopulateUniqueTargetsList(transform.position, radius);
            if (count == 0)
                return;

            float team1Count = 0;
            float team2Count = 0;
            unique.ForEach(c => {
                switch (c.Team)
                {
                    case 0:
                        team1Count++;
                        break;
                    case 1:
                        team2Count++;
                        break;
                    default:
                        break;
                }
            });

            if (team1Count / 2 > team2Count) {
                team1Progress += Time.deltaTime * scaling;
                team1ProgressImage.fillAmount = team1Progress / maxProgress / 2;

                if (team1Progress < maxProgress)
                    return;

            } else if (team2Count / 2 > team1Count) {
                team2Progress += Time.deltaTime * scaling;
                team2ProgressImage.fillAmount = team2Progress / maxProgress / 2;

                if (team2Progress < maxProgress)
                    return;

            } else
                return;

            enabled = false;
        }

        private int PopulateUniqueTargetsList(Vector3 position, float radius) {
            //  TODO: Layermask            
            int len = Physics2D.OverlapCircleNonAlloc(position, radius, hitObjects, mask);
            for (int t = 0; t < len; t++) {
                var root = hitObjects[t].transform.root.gameObject;
                if (root == gameObject)
                    continue;

                var character = root.GetComponent<Character>();
                if (unique.Contains(character))
                    continue;

                unique.Add(character);
            }
            return unique.Count;
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
