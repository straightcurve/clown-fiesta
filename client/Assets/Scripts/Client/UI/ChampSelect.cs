using System;
using System.Collections.Generic;
using C_Services;
using Helpers;
using Parsers;
using UnityEngine;

namespace UI
{
    public class ChampSelect : MonoBehaviour
    {
        [SerializeField] string gameScene = "local";
        [SerializeField] GameObject championDataPrefab;
        [SerializeField] Transform championDataParent;
        [SerializeField] List<AbilityDataListElement> abilities;
        [SerializeField] Transform modelParent;

        private GameObject currentModel;
        private string currentModelPath;

        ISceneService sceneService;

        private void Awake()
        {
            LoadChampions();
            sceneService = new SceneService();
        }

        public void LoadChampions()
        {
            var data = JsonParser.FromFile<ChampionListData>($"{Application.dataPath}/Data/champions.json");

            data.list.ForEach(champion =>
            {
                //  create a new ui object and assign data to it
                var element = Instantiate(championDataPrefab, championDataParent).GetComponent<ChampionDataListElement>();
                element
                    .SetName(champion.name)
                    .SetPortrait(champion.iconPath)
                    .SetModelPath(champion.modelPath)
                    .OnClick(LoadModel);

                var count = Math.Min(champion.abilities.Count, abilities.Count);

                for (int i = 0; i < count; i++)
                {
                    abilities[i]
                        .SetName(champion.abilities[i].name)
                        .SetIcon(champion.abilities[i].iconPath)
                        .SetDescription(champion.abilities[i].description);
                }
            });
        }

        private void LoadModel(string path)
        {
            if (currentModel != null)
            {
                Destroy(currentModel);
                currentModelPath = "";
            }

            var prefab = Resources.Load<GameObject>(path);
            if (prefab == null)
            {
                Debug.LogError($"Couldn't load model at path: {path}");
                return;
            }

            currentModel = Instantiate(prefab, modelParent);
            currentModelPath = path;
        }

        public void LockIn()
        {
            //  TODO: Cleaner way of handling data passing between scenes
            //  HACK: Maybe?
            var data = Resources.Load<SharedData>("SharedData");
            data.lockedInModelPath = currentModelPath;
            sceneService.Load(gameScene);
        }

        [Serializable]
        private struct ChampionListData
        {
            public List<ChampionData> list;
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
