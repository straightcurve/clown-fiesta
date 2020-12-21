using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClownFiesta.Core.UI {

    [CreateAssetMenu(menuName = "New/Menu", fileName = "Menu")]
    public class MenuData : ScriptableObject {

        public List<string> tabs;
        public List<GameObject> pages;

    }
}
