using System.Collections;
using ClownFiesta.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

using Text = TMPro.TextMeshProUGUI;

public class ControlPointHandler: MonoBehaviour {

    [SerializeField] private float timeoutBeforeReload = 3f;
    [SerializeField] private GameObject ui;
    [SerializeField] private Text flavor;

    private Coroutine coroutine;

    private void Awake() {
         if (ui == null)
            throw new UnityException("ui is null");

        if (flavor == null)
            throw new UnityException("flavor is null");
    }

    public void OnCapturedObjective(CapturedEventArgs args) {
        coroutine = StartCoroutine(ReloadDebugScene(args.By));
    }

    private IEnumerator ReloadDebugScene(int team) {
        ui.SetActive(true);
        flavor.text = $"Team {team + 1} won!";

        yield return new WaitForSeconds(timeoutBeforeReload);

        SceneManager.LoadScene("debug", LoadSceneMode.Single);

        StopCoroutine(coroutine);
    }
}