using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace UI
{
    public class ChampionDataListElement : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image portrait;
        [SerializeField] Button button;
        private string modelPath;

        event Action<string> Clicked;

        private void Awake()
        {
            if (button == null)
                Debug.LogError("Button not assigned", this);
            else
                button.onClick.AddListener(() => Clicked?.Invoke(modelPath));
        }

        public ChampionDataListElement SetName(string name)
        {
            this.nameText.text = this.name = name;
            return this;
        }

        public ChampionDataListElement SetPortrait(string path)
        {
            var icon = Resources.Load<Sprite>(path);
            this.portrait.sprite = icon;
            return this;
        }

        public ChampionDataListElement SetModelPath(string path)
        {
            this.modelPath = path;
            return this;
        }

        public void OnClick(Action<string> callback)
        {
            Clicked += callback;
        }
    }
}