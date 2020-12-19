using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.UI;

namespace ClownFiesta.Core {

    public class Teams {
        public const int MaxPlayerCount = 16;
        public readonly List<Character> First = new List<Character>(MaxPlayerCount / 2);
        public readonly List<Character> Second = new List<Character>(MaxPlayerCount / 2);


        public void AddToFirstTeam(Character character) {
            if (First.Any(c => c.ActualCharacter == character.ActualCharacter))
                return;

            character.Team = 0;
            First.Add(character);
        }

        public void AddToSecondTeam(Character character) {
            if (Second.Any(c => c.ActualCharacter == character.ActualCharacter))
                return;

            character.Team = 1;
            Second.Add(character);
        }
    }
}
