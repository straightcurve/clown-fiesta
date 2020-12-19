// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/CharacterControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ClownFiesta.Core
{
    public class @CharacterControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CharacterControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""8432de1f-d2f1-43b0-bda9-f97a5622999a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a0cf30b8-4981-4b59-b54f-b2a737a9bd86"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q"",
                    ""type"": ""Button"",
                    ""id"": ""df343ee2-ca44-4647-b36e-4a7346e66230"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""db6c62df-43d6-4da8-8aa1-634896865eea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""1c596641-c1f6-436b-a829-73b2d9f09766"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68248422-05b7-4f2b-a543-e29920eb68e2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2d58e9a6-c7e9-4c90-baa9-cc477c9d5703"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aa6d4235-cadd-4a74-9931-a1dbddbde802"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4eac840d-c66f-4f11-a832-e3ba9e675281"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9d85c2e4-e8a2-4524-982e-ad094a961ba3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cffc2b20-4e0d-4ce2-94b5-15b4e3378467"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ef0186a8-6302-4df1-b4f6-a604db2d3331"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""003443aa-8a6f-4d7a-93ef-75b8cb3dde77"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""434bad35-81f5-44c6-9fae-40733a14d43c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44c9122c-bb34-4f58-b0dd-e74edb8405d6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61794ed5-08c7-487a-a031-e0ea143bee70"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Team Selection"",
            ""id"": ""6109fddb-7a6c-4e02-a49d-ed110c30def3"",
            ""actions"": [
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""66c48ee1-2953-4e9e-94db-db52a6d96e61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""45d3690f-2c14-4b72-8f79-37600f1edde9"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5ba64b5f-017c-457b-b9c8-d3cb3982758e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94359cca-7d88-42b4-a544-10289f3dda8e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""247971c8-6c1e-4a16-a0a0-30d2c593f0fb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5adaec30-4754-4223-9f4d-da8e59278310"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7d7f5911-10a0-4538-b6b9-fe7bd5f113af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0c5d5cf3-9f30-45c7-a856-d36b4e72d80b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9ee50053-aea3-40ec-8190-e9f0072ce37b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""907c7794-e7f4-45ae-aa5b-fe7aaa526d55"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KB+M"",
            ""bindingGroup"": ""KB+M"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
            m_Gameplay_Q = m_Gameplay.FindAction("Q", throwIfNotFound: true);
            m_Gameplay_E = m_Gameplay.FindAction("E", throwIfNotFound: true);
            m_Gameplay_Aim = m_Gameplay.FindAction("Aim", throwIfNotFound: true);
            // Team Selection
            m_TeamSelection = asset.FindActionMap("Team Selection", throwIfNotFound: true);
            m_TeamSelection_Close = m_TeamSelection.FindAction("Close", throwIfNotFound: true);
            m_TeamSelection_Move = m_TeamSelection.FindAction("Move", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_Move;
        private readonly InputAction m_Gameplay_Q;
        private readonly InputAction m_Gameplay_E;
        private readonly InputAction m_Gameplay_Aim;
        public struct GameplayActions
        {
            private @CharacterControls m_Wrapper;
            public GameplayActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @Q => m_Wrapper.m_Gameplay_Q;
            public InputAction @E => m_Wrapper.m_Gameplay_E;
            public InputAction @Aim => m_Wrapper.m_Gameplay_Aim;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Q.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnQ;
                    @Q.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnQ;
                    @Q.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnQ;
                    @E.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnE;
                    @E.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnE;
                    @E.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnE;
                    @Aim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                    @Aim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                    @Aim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Q.started += instance.OnQ;
                    @Q.performed += instance.OnQ;
                    @Q.canceled += instance.OnQ;
                    @E.started += instance.OnE;
                    @E.performed += instance.OnE;
                    @E.canceled += instance.OnE;
                    @Aim.started += instance.OnAim;
                    @Aim.performed += instance.OnAim;
                    @Aim.canceled += instance.OnAim;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // Team Selection
        private readonly InputActionMap m_TeamSelection;
        private ITeamSelectionActions m_TeamSelectionActionsCallbackInterface;
        private readonly InputAction m_TeamSelection_Close;
        private readonly InputAction m_TeamSelection_Move;
        public struct TeamSelectionActions
        {
            private @CharacterControls m_Wrapper;
            public TeamSelectionActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Close => m_Wrapper.m_TeamSelection_Close;
            public InputAction @Move => m_Wrapper.m_TeamSelection_Move;
            public InputActionMap Get() { return m_Wrapper.m_TeamSelection; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TeamSelectionActions set) { return set.Get(); }
            public void SetCallbacks(ITeamSelectionActions instance)
            {
                if (m_Wrapper.m_TeamSelectionActionsCallbackInterface != null)
                {
                    @Close.started -= m_Wrapper.m_TeamSelectionActionsCallbackInterface.OnClose;
                    @Close.performed -= m_Wrapper.m_TeamSelectionActionsCallbackInterface.OnClose;
                    @Close.canceled -= m_Wrapper.m_TeamSelectionActionsCallbackInterface.OnClose;
                    @Move.started -= m_Wrapper.m_TeamSelectionActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_TeamSelectionActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_TeamSelectionActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_TeamSelectionActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Close.started += instance.OnClose;
                    @Close.performed += instance.OnClose;
                    @Close.canceled += instance.OnClose;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public TeamSelectionActions @TeamSelection => new TeamSelectionActions(this);
        private int m_KBMSchemeIndex = -1;
        public InputControlScheme KBMScheme
        {
            get
            {
                if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KB+M");
                return asset.controlSchemes[m_KBMSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface IGameplayActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnQ(InputAction.CallbackContext context);
            void OnE(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
        }
        public interface ITeamSelectionActions
        {
            void OnClose(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
        }
    }
}
