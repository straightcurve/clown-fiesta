using UnityEngine.SceneManagement;
using SM = UnityEngine.SceneManagement.SceneManager;

namespace C_Services
{
    public interface ISceneService
    {
        void Load(string scene, LoadSceneMode mode = LoadSceneMode.Single);
    }

    public class SceneService : ISceneService
    {
        public void Load(string scene, LoadSceneMode mode = LoadSceneMode.Single)
        {
            SM.LoadScene(scene, mode);
        }
    }
}