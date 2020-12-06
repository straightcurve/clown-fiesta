using UnityEngine;

namespace ClownFiesta.Networking
{
    public class UIHandler: MonoBehaviour {

        public void CreateGame() {
            Transport.Send("create-game");
            PickCharacter();
        }

        public void PickCharacter(string character = "keqing") {
            Transport.Send($"pick-character|{character}");
        }
    }
}
