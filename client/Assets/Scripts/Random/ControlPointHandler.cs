using ClownFiesta.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPointHandler: MonoBehaviour {
    public void OnCapturedObjective(CapturedEventArgs args) {
        print($"Team {args.By + 1} won!");

        SceneManager.LoadScene("debug", LoadSceneMode.Single);
    }
}