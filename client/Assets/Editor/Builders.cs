using UnityEditor;

namespace Automation
{
    public class Builders
    {
        private static string[] scenes = {
            "Assets/_Scenes/main.unity",
            "Assets/_Scenes/champ_select.unity",
            "Assets/_Scenes/local.unity",
            "Assets/_Scenes/test_area.unity"
        };

        public static void Build_win()
        {
            Build_win_x86();
            Build_win_x64();
        }

        public static void Build_win_x86()
        {
            string pathToDeploy = "./build/win_x86/game.exe";
            BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.StandaloneWindows, BuildOptions.Development | BuildOptions.StrictMode);
        }

        public static void Build_win_x64()
        {
            string pathToDeploy = "./build/win_x64/game.exe";
            BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.StandaloneWindows64, BuildOptions.Development | BuildOptions.StrictMode);
        }

        public static void Build_linux()
        {
            string pathToDeploy = "./build/linux/game.86_64";
            BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.StandaloneLinux64, BuildOptions.Development | BuildOptions.StrictMode);
        }
    }
}