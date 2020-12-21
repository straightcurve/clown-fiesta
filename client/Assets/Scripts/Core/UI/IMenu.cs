using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace ClownFiesta.Core.UI {

    public interface IMenu {
        PlayerController Controller { get; set; }
    }
}
