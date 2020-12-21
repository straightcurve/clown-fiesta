using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace ClownFiesta.Core.UI {

    public class Menu : MonoBehaviour {

        [SerializeField] private InputSystemUIInputModule uiInputModule;
        [SerializeField] private List<GameObject> tabs;
        [SerializeField] private List<GameObject> pages;

        public PlayerController Controller {
            get => controller;
            set {
                controller = value;

                controller.Input.uiInputModule = uiInputModule;
            }
        }
        private PlayerController controller;

        private GameObject currentPage;

        private void Start() {
            if (tabs.Count == 0 || tabs.Count != pages.Count)
                return;

            for (int t = 0; t < tabs.Count; t++) {
                var tab = tabs[t];
                var clown = t;
                tab.GetComponent<Button>().onClick.AddListener(() => {
                    if (currentPage != null)
                        currentPage.SetActive(false);

                    currentPage = pages[clown];
                    var menu = currentPage.GetComponent<IMenu>();
                    menu.Controller = Controller;
                    currentPage.SetActive(true);
                });
            }

            Controller.Input.actions.FindActionMap("UI").FindAction("Close").started += Close;
            Controller.Input.actions.FindActionMap("Gameplay").FindAction("Open Menu").started += Open;

            tabs[0].GetComponent<Button>().onClick.Invoke();
        }

        private void Open(InputAction.CallbackContext ctx) {
            Controller.Input.SwitchCurrentActionMap("UI");

            gameObject.SetActive(true);

            OpenFirstTab();
        }

        private void OpenFirstTab() {
            tabs[0].GetComponent<Button>().onClick.Invoke();
        }

        private void Close(InputAction.CallbackContext ctx) {
            gameObject.SetActive(false);

            Controller.Input.SwitchCurrentActionMap("Gameplay");
        }
    }
}
