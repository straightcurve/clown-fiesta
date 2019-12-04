using UI;
using UnityEngine;

namespace Helpers
{
    public static class PopupTextHelper
    {
        private static GameObject prefab;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            prefab = Resources.Load<GameObject>("Prefabs/UI/Damage Popup Text");
        }

        public static void Spawn(Transform parent, Vector3 position, string text)
        {
            var popup = MonoBehaviour.Instantiate(prefab, parent.transform).GetComponent<PopupText>();
            popup.SetText(text);
            popup.transform.position = position;
            MonoBehaviour.Destroy(popup, 2f);
        }
    }
}