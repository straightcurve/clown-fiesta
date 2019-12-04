using UnityEngine;

namespace Helpers
{
    [CreateAssetMenu(menuName = "Data/Shared", fileName = "SharedData")]
    public class SharedData : ScriptableObject
    {
        public string lockedInModelPath;
    }
}