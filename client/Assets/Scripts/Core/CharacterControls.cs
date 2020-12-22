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
                },
                {
                    ""name"": ""Open Team Selection Menu"",
                    ""type"": ""Button"",
                    ""id"": ""063afbc5-57b6-4370-8eca-91f850f8a36b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Open Menu"",
                    ""type"": ""Button"",
                    ""id"": ""120509a4-edc8-4daa-99d5-3d14dadf32fe"",
                    ""expectedControlType"": ""Button"",
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
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""4fb13521-69d5-4295-a0e2-514ba4ad433d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Team Selection Menu"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""892bb17e-cffc-4ced-83a5-2b16dac6426c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Open Team Selection Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""a60091ba-09a6-4119-8a12-2e3f9bfe9033"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Open Team Selection Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3f097eca-db39-4bb9-b55c-1c8b6fafb2c9"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Open Team Selection Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""025d2d44-3ea8-4d94-84cd-c5ad33704499"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Open Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a98dc98-7d9b-49d9-8a5b-b1083e7d6fba"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Open Menu"",
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
                    ""id"": ""08328f2c-bd39-46a4-889c-48c4c4d008d2"",
                    ""path"": ""<Keyboard>/o"",
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
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""0c520d36-b2ec-4b56-b18d-b5b946844f30"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""9c9cd432-8f79-4b2c-b82c-3abed18eef6e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c37736fb-0bda-4505-a597-9f6155456dd2"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        },
        {
            ""name"": ""UI"",
            ""id"": ""33730048-dcff-4159-aa54-8019ed597cff"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8491bb90-521a-4dae-bba0-575e2b8f058c"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""b0857321-964a-49d1-9cad-5a9266d519d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""541cb34f-c4a6-41a7-87bf-67ecfbeff585"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""5e687bd8-0805-41e1-9153-d671de739609"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Previous"",
                    ""type"": ""Button"",
                    ""id"": ""3542d2ce-4b89-4aa7-9a51-e93fd4501e54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5e580202-4698-43e1-8a2f-698e25c434cd"",
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
                    ""id"": ""af1f253b-de18-49db-9fcc-e20f5657a723"",
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
                    ""id"": ""c43a4ffd-3d54-4cbd-a642-09c9bf2e6754"",
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
                    ""id"": ""7ba0fb36-0912-45e9-b052-c74ac59c073d"",
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
                    ""id"": ""728ce4ef-c908-4af3-bd47-d21a213d8731"",
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
                    ""id"": ""8384d33d-1e61-4187-9aa1-65bbd4741845"",
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
                    ""id"": ""f70bebf6-0b1c-4294-a69b-bcb309fde9bd"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed715265-6f69-4593-b3ae-ffb386aa16c6"",
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
                    ""id"": ""2b4d0ab3-c9b3-4895-9cf8-dc2d9a37c9b7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3a0b3ac-69d4-4ba2-aeca-78bc71fec34a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62000197-251c-422a-8016-7379e1ac3bc0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""600fc7e4-87c3-4a19-a6d3-4da3e58548f0"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4c20e0a-55ce-4bf6-bf34-581ae48e35ca"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f77343b5-a54e-49ac-88ca-5816292ab746"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
            m_Gameplay_OpenTeamSelectionMenu = m_Gameplay.FindAction("Open Team Selection Menu", throwIfNotFound: true);
            m_Gameplay_OpenMenu = m_Gameplay.FindAction("Open Menu", throwIfNotFound: true);
            // Team Selection
            m_TeamSelection = asset.FindActionMap("Team Selection", throwIfNotFound: true);
            m_TeamSelection_Close = m_TeamSelection.FindAction("Close", throwIfNotFound: true);
            m_TeamSelection_Move = m_TeamSelection.FindAction("Move", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Move = m_UI.FindAction("Move", throwIfNotFound: true);
            m_UI_Close = m_UI.FindAction("Close", throwIfNotFound: true);
            m_UI_Accept = m_UI.FindAction("Accept", throwIfNotFound: true);
            m_UI_Next = m_UI.FindAction("Next", throwIfNotFound: true);
            m_UI_Previous = m_UI.FindAction("Previous", throwIfNotFound: true);
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
        private readonly InputAction m_Gameplay_OpenTeamSelectionMenu;
        private readonly InputAction m_Gameplay_OpenMenu;
        public struct GameplayActions
        {
            private @CharacterControls m_Wrapper;
            public GameplayActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @Q => m_Wrapper.m_Gameplay_Q;
            public InputAction @E => m_Wrapper.m_Gameplay_E;
            public InputAction @Aim => m_Wrapper.m_Gameplay_Aim;
            public InputAction @OpenTeamSelectionMenu => m_Wrapper.m_Gameplay_OpenTeamSelectionMenu;
            public InputAction @OpenMenu => m_Wrapper.m_Gameplay_OpenMenu;
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
                    @OpenTeamSelectionMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenTeamSelectionMenu;
                    @OpenTeamSelectionMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenTeamSelectionMenu;
                    @OpenTeamSelectionMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenTeamSelectionMenu;
                    @OpenMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenMenu;
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
                    @OpenTeamSelectionMenu.started += instance.OnOpenTeamSelectionMenu;
                    @OpenTeamSelectionMenu.performed += instance.OnOpenTeamSelectionMenu;
                    @OpenTeamSelectionMenu.canceled += instance.OnOpenTeamSelectionMenu;
                    @OpenMenu.started += instance.OnOpenMenu;
                    @OpenMenu.performed += instance.OnOpenMenu;
                    @OpenMenu.canceled += instance.OnOpenMenu;
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

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Move;
        private readonly InputAction m_UI_Close;
        private readonly InputAction m_UI_Accept;
        private readonly InputAction m_UI_Next;
        private readonly InputAction m_UI_Previous;
        public struct UIActions
        {
            private @CharacterControls m_Wrapper;
            public UIActions(@CharacterControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_UI_Move;
            public InputAction @Close => m_Wrapper.m_UI_Close;
            public InputAction @Accept => m_Wrapper.m_UI_Accept;
            public InputAction @Next => m_Wrapper.m_UI_Next;
            public InputAction @Previous => m_Wrapper.m_UI_Previous;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                    @Close.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClose;
                    @Close.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClose;
                    @Close.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClose;
                    @Accept.started -= m_Wrapper.m_UIActionsCallbackInterface.OnAccept;
                    @Accept.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnAccept;
                    @Accept.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnAccept;
                    @Next.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNext;
                    @Next.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNext;
                    @Next.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNext;
                    @Previous.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPrevious;
                    @Previous.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPrevious;
                    @Previous.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPrevious;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Close.started += instance.OnClose;
                    @Close.performed += instance.OnClose;
                    @Close.canceled += instance.OnClose;
                    @Accept.started += instance.OnAccept;
                    @Accept.performed += instance.OnAccept;
                    @Accept.canceled += instance.OnAccept;
                    @Next.started += instance.OnNext;
                    @Next.performed += instance.OnNext;
                    @Next.canceled += instance.OnNext;
                    @Previous.started += instance.OnPrevious;
                    @Previous.performed += instance.OnPrevious;
                    @Previous.canceled += instance.OnPrevious;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
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
            void OnOpenTeamSelectionMenu(InputAction.CallbackContext context);
            void OnOpenMenu(InputAction.CallbackContext context);
        }
        public interface ITeamSelectionActions
        {
            void OnClose(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnClose(InputAction.CallbackContext context);
            void OnAccept(InputAction.CallbackContext context);
            void OnNext(InputAction.CallbackContext context);
            void OnPrevious(InputAction.CallbackContext context);
        }
    }
}
