using UnityEngine;
using TMPro;

namespace UI
{
    public class PopupText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;

        public PopupText SetText(string text)
        {
            this.text.text = text;
            return this;
        }
    }
}
