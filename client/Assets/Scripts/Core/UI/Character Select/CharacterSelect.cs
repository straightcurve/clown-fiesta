using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClownFiesta.Core.UI.CharacterSelect {
    public class CharacterSelect : MonoBehaviour {
        [SerializeField] string gameScene = "debug";
        [SerializeField] GameObject selectableCharacterPrefab;
        [SerializeField] Transform grid;
        [SerializeField] Transform modelParent;

        private GameObject currentModel;
        private GameObject modelPrefab;

        private void Awake() {
            LoadCharacters();
        }

        public void LoadCharacters() {
            var characters = Resources.LoadAll<SelectableCharacter>("Selectable Characters");

            characters.ToList().ForEach(character =>
            {
                //  create a new ui object and assign data to it
                var element = Instantiate(selectableCharacterPrefab, grid).GetComponent<SelectableCharacterListElement>();
                element
                    .SetName(character.characterName)
                    .SetPortrait(character.portrait)
                    .SetModel(character.model)
                    .OnClick(LoadModel);

                // var count = Math.Min(character.abilities.Count, abilities.Count);

                // for (int i = 0; i < count; i++)
                // {
                //     abilities[i]
                //         .SetName(character.abilities[i].name)
                //         .SetIcon(character.abilities[i].iconPath)
                //         .SetDescription(character.abilities[i].description);
                // }
            });
        }

        private void LoadModel(GameObject model) {
            if (currentModel != null)
                Destroy(currentModel);

            currentModel = Instantiate(model, modelParent);
            modelPrefab = model;
        }

        public void LockIn() {
            //  TODO: Cleaner way of handling data passing between scenes
            //  HACK: Maybe?
            var data = Resources.Load<CharacterSelectSceneData>("CharacterSelectSceneData");
            data.model = modelPrefab;
            SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
        }

        [Serializable]
        private struct ChampionData
        {
            public string name;
            public string iconPath;
            public string modelPath;
            public List<AbilityData> abilities;
        }

        [Serializable]
        private struct AbilityData
        {
            public string name;
            public string iconPath;
            public string description;
        }
    }
}
