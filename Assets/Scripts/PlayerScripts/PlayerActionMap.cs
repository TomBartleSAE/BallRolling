// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerScripts/PlayerActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActionMap"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""47d8e587-65e6-4d54-90e5-efde1284e6a9"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e7a95867-76a8-424d-bc5a-cf11ee1db597"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookDirection"",
                    ""type"": ""Value"",
                    ""id"": ""ce872378-488c-46a8-9d9a-2b811e2addd0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Value"",
                    ""id"": ""bb8fe5c6-e2c9-40ce-a249-1ade864d5cda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""544449ba-177d-48e1-92f7-4b457a5fef5c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9360bb4f-3a45-4b9e-b0c5-86ff9b84810f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d530943e-ebac-4e82-ba97-0bf767b5b818"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""27ed8100-fba8-42eb-89fc-999b5f51ba0d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""41be0b57-41d4-4df4-b107-9b2e5b06f3f0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9d86b426-2d50-4d2a-b576-3624d02c4d8c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""733164aa-05a8-46e9-be99-342caea15c72"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1fdea02e-fde7-45bf-82aa-8c5368013e74"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f1ad05a4-08e7-4b1f-8e67-8bdf933fb14d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""961fd680-7d42-45a5-92bb-b3157e780598"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""96530446-b1eb-48e8-8894-585ca34d37e0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LookDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b3faa531-8d32-4d1f-9064-263a7716ec85"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b4cb4514-44da-4361-8775-fe3bafd2eb95"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LookDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""96560b85-9d2d-44ff-b8ee-d27bd67ea9d0"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LookDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""736eb62a-c425-46fd-9a9a-e9352a18ad11"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LookDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6e5b0d63-e1c1-4118-8120-8a6f8528f54c"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LookDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc655237-d5f5-4330-9371-2aabbaba986c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""860586a6-d68f-435e-bad4-260dd7b116f8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InMenu"",
            ""id"": ""359df84c-0240-4720-8f6a-417631dd4d82"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""93a164d4-5d81-4d10-95ea-dcab181bf9ff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""6c1d43e6-85e0-4d15-8183-de85ca078eaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""56497d3c-a21b-4606-b946-859266eec527"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a45dbc60-7c96-44e0-8c34-5062cda8897a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f9fe0dc6-ea86-4a72-a6c5-e0934164392b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7da4ae85-3284-4f00-b73f-ec0125e3b839"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a6d50bf3-d293-4fde-b7a5-e9be95c4d767"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""79e28822-aae9-4c8e-aa56-77743007a662"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""df32966b-c999-49ef-8a77-3dd01cf9543a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6b4e7c20-564b-44f8-90f6-2c93083962a8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f1b03b78-ebaa-4d26-b2d6-96edbc815e77"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""64cb3572-c62e-460e-8388-454f800383a1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c185f110-524f-4d2a-8fe6-ce6d23a4c4e6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1df07cc-2103-4932-9405-ba18becb15f4"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
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
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Movement = m_InGame.FindAction("Movement", throwIfNotFound: true);
        m_InGame_LookDirection = m_InGame.FindAction("LookDirection", throwIfNotFound: true);
        m_InGame_Ability = m_InGame.FindAction("Ability", throwIfNotFound: true);
        // InMenu
        m_InMenu = asset.FindActionMap("InMenu", throwIfNotFound: true);
        m_InMenu_Navigate = m_InMenu.FindAction("Navigate", throwIfNotFound: true);
        m_InMenu_Select = m_InMenu.FindAction("Select", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Movement;
    private readonly InputAction m_InGame_LookDirection;
    private readonly InputAction m_InGame_Ability;
    public struct InGameActions
    {
        private @PlayerActionMap m_Wrapper;
        public InGameActions(@PlayerActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_InGame_Movement;
        public InputAction @LookDirection => m_Wrapper.m_InGame_LookDirection;
        public InputAction @Ability => m_Wrapper.m_InGame_Ability;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMovement;
                @LookDirection.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookDirection;
                @LookDirection.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookDirection;
                @LookDirection.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnLookDirection;
                @Ability.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnAbility;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @LookDirection.started += instance.OnLookDirection;
                @LookDirection.performed += instance.OnLookDirection;
                @LookDirection.canceled += instance.OnLookDirection;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // InMenu
    private readonly InputActionMap m_InMenu;
    private IInMenuActions m_InMenuActionsCallbackInterface;
    private readonly InputAction m_InMenu_Navigate;
    private readonly InputAction m_InMenu_Select;
    public struct InMenuActions
    {
        private @PlayerActionMap m_Wrapper;
        public InMenuActions(@PlayerActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_InMenu_Navigate;
        public InputAction @Select => m_Wrapper.m_InMenu_Select;
        public InputActionMap Get() { return m_Wrapper.m_InMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInMenuActions instance)
        {
            if (m_Wrapper.m_InMenuActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_InMenuActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_InMenuActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_InMenuActionsCallbackInterface.OnNavigate;
                @Select.started -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_InMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public InMenuActions @InMenu => new InMenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLookDirection(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
    }
    public interface IInMenuActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
