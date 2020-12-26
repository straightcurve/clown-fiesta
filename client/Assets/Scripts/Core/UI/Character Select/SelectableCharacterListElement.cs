using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace ClownFiesta.Core.UI.CharacterSelect {
    public class SelectableCharacterListElement : MonoBehaviour {

        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image portrait;
        [SerializeField] Button button;
        private GameObject model;

        event Action<GameObject> Clicked;

        private void Awake()
        {
            if (button == null)
                Debug.LogError("Button not assigned", this);
            else
                button.onClick.AddListener(() => Clicked?.Invoke(model));
        }

        public SelectableCharacterListElement SetName(string name)
        {
            this.nameText.text = this.name = name;
            return this;
        }

        public SelectableCharacterListElement SetPortrait(Sprite portrait)
        {
            this.portrait.sprite = portrait;
            return this;
        }

        public SelectableCharacterListElement SetModel(GameObject model)
        {
            this.model = model;
            return this;
        }

        public void OnClick(Action<GameObject> callback)
        {
            Clicked += callback;
        }
    }
}