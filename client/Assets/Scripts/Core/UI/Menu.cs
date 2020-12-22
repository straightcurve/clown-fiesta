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

        private readonly List<IMenu> menus = new List<IMenu>();
        private GameObject currentPage;
        private int currentTab;

        private void Start() {
            if (tabs.Count == 0 || tabs.Count != pages.Count)
                return;

            for (int t = 0; t < tabs.Count; t++) {
                var menu = pages[t].GetComponent<IMenu>();
                menu.Controller = Controller;
                menus.Add(menu);

                var tab = tabs[t];
                var clown = t;
                tab.GetComponent<Button>().onClick.AddListener(() => {
                    if (currentPage != null)
                        currentPage.SetActive(false);

                    currentTab = clown;
                    currentPage = pages[clown];
                    currentPage.SetActive(true);
                });
            }

            Controller.Input.actions.FindActionMap("UI").FindAction("Close").started += Close;
            Controller.Input.actions.FindActionMap("UI").FindAction("Previous").started += GoToPreviousTab;
            Controller.Input.actions.FindActionMap("UI").FindAction("Next").started += GoToNextTab;
            Controller.Input.actions.FindActionMap("Gameplay").FindAction("Open Menu").started += Open;

            tabs[0].GetComponent<Button>().onClick.Invoke();
        }

        private void GoToPreviousTab(InputAction.CallbackContext ctx) {
            print("wat");
            if (currentTab == 0)
                return;

            var current = currentTab;
            var selectable = false;
            while (current > 0 && !selectable)
                selectable = menus[--current].Selectable;
            
            if (selectable)
                tabs[current].GetComponent<Button>().onClick.Invoke();
        }

        private void GoToNextTab(InputAction.CallbackContext ctx) {
            if (currentTab == tabs.Count - 1)
                return;

            var count = tabs.Count - 1;
            var current = currentTab;
            var selectable = false;
            while (current < count && !selectable)
                selectable = menus[++current].Selectable;
            
            if (selectable)
                tabs[current].GetComponent<Button>().onClick.Invoke();
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

        private void OnDestroy() {
            if (Controller == null)
                return;

            Controller.Input.actions.FindActionMap("UI").FindAction("Close").started -= Close;
            Controller.Input.actions.FindActionMap("UI").FindAction("Previous").started -= GoToPreviousTab;
            Controller.Input.actions.FindActionMap("UI").FindAction("Next").started -= GoToNextTab;
            Controller.Input.actions.FindActionMap("Gameplay").FindAction("Open Menu").started -= Open;
        }
    }
}
