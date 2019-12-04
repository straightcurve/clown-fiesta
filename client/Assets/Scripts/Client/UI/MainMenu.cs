using C_Services;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] bool local;
        [SerializeField] string defaultLocalScene = "champ_select";
        [SerializeField] string defaultNetworkedScene = "client";
        private ISceneService sceneService;

        private void Awake()
        {
            Construct(new SceneService());
        }

        public void Construct(ISceneService sceneService)
        {
            this.sceneService = sceneService;
        }

        public void Play()
        {
            if (local)
            {
                sceneService.Load(defaultLocalScene);
            }
            else
            {
                sceneService.Load(defaultNetworkedScene);
            }
        }

        public void Options()
        {
            //  open the options panel
            Debug.LogError("Options panel not implemented!");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}