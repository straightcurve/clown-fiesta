using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AbilityDataListElement : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image icon;
        [SerializeField] TextMeshProUGUI descriptionText;

        public AbilityDataListElement SetName(string name)
        {
            this.nameText.text = this.name = name;
            return this;
        }

        public AbilityDataListElement SetIcon(string path)
        {
            var icon = Resources.Load<Sprite>(path);
            this.icon.sprite = icon;
            return this;
        }

        public AbilityDataListElement SetDescription(string description)
        {
            this.descriptionText.text = description;
            return this;
        }
    }
}