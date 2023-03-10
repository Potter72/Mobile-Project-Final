//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""00f49548-3e3e-4b95-85dd-09f3dbb1cdc0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a7f1397c-3e64-4316-a42f-b4f5650527e3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SpecialButton"",
                    ""type"": ""Button"",
                    ""id"": ""e80328bf-1a1d-4e99-8c86-1a8bf47ac863"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SpecialStick"",
                    ""type"": ""Value"",
                    ""id"": ""35cc39d4-4d3b-4560-bf69-3cbf942f7ee0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4b5d88eb-a518-4ad4-8b09-63136be61955"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchEquipment"",
                    ""type"": ""Button"",
                    ""id"": ""c050ac69-3b00-4b18-93c7-5ef8d48abe32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchCharacter1"",
                    ""type"": ""Button"",
                    ""id"": ""fee4bd67-cc14-44c5-8491-f0e7a7669064"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchCharacter2"",
                    ""type"": ""Button"",
                    ""id"": ""21b65760-9caf-4119-8786-609a1bdf20c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchCharacter3"",
                    ""type"": ""Button"",
                    ""id"": ""1bb062d5-1bda-435d-935c-13162c89942a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fcd68671-89ea-4358-9032-5af39d68785a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0467a811-ecf8-42d3-bcd6-d4b9360dda2b"",
                    ""path"": ""<AndroidJoystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5532d1ba-62af-467c-8cf1-4a03b8f26ef0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9659bb2-1fc7-4df6-8b87-063d7361dde6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07dfc123-4fd5-48e6-9eb5-3a3ae1afc278"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCharacter1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2defa23-848a-4d9b-837b-5ea31c79e840"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCharacter2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c568dab-aa2d-40f1-9ecd-3c60bce12495"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCharacter3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57abb6d8-afe2-4cac-b91b-61727a2e7f5b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfec9662-6c52-4488-9c12-7c2c2822a78c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchEquipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_SpecialButton = m_Player.FindAction("SpecialButton", throwIfNotFound: true);
        m_Player_SpecialStick = m_Player.FindAction("SpecialStick", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_SwitchEquipment = m_Player.FindAction("SwitchEquipment", throwIfNotFound: true);
        m_Player_SwitchCharacter1 = m_Player.FindAction("SwitchCharacter1", throwIfNotFound: true);
        m_Player_SwitchCharacter2 = m_Player.FindAction("SwitchCharacter2", throwIfNotFound: true);
        m_Player_SwitchCharacter3 = m_Player.FindAction("SwitchCharacter3", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_SpecialButton;
    private readonly InputAction m_Player_SpecialStick;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_SwitchEquipment;
    private readonly InputAction m_Player_SwitchCharacter1;
    private readonly InputAction m_Player_SwitchCharacter2;
    private readonly InputAction m_Player_SwitchCharacter3;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @SpecialButton => m_Wrapper.m_Player_SpecialButton;
        public InputAction @SpecialStick => m_Wrapper.m_Player_SpecialStick;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @SwitchEquipment => m_Wrapper.m_Player_SwitchEquipment;
        public InputAction @SwitchCharacter1 => m_Wrapper.m_Player_SwitchCharacter1;
        public InputAction @SwitchCharacter2 => m_Wrapper.m_Player_SwitchCharacter2;
        public InputAction @SwitchCharacter3 => m_Wrapper.m_Player_SwitchCharacter3;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @SpecialButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecialButton;
                @SpecialButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecialButton;
                @SpecialButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecialButton;
                @SpecialStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecialStick;
                @SpecialStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecialStick;
                @SpecialStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpecialStick;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @SwitchEquipment.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchEquipment;
                @SwitchEquipment.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchEquipment;
                @SwitchEquipment.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchEquipment;
                @SwitchCharacter1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter1;
                @SwitchCharacter1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter1;
                @SwitchCharacter1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter1;
                @SwitchCharacter2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter2;
                @SwitchCharacter2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter2;
                @SwitchCharacter2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter2;
                @SwitchCharacter3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter3;
                @SwitchCharacter3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter3;
                @SwitchCharacter3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwitchCharacter3;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @SpecialButton.started += instance.OnSpecialButton;
                @SpecialButton.performed += instance.OnSpecialButton;
                @SpecialButton.canceled += instance.OnSpecialButton;
                @SpecialStick.started += instance.OnSpecialStick;
                @SpecialStick.performed += instance.OnSpecialStick;
                @SpecialStick.canceled += instance.OnSpecialStick;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @SwitchEquipment.started += instance.OnSwitchEquipment;
                @SwitchEquipment.performed += instance.OnSwitchEquipment;
                @SwitchEquipment.canceled += instance.OnSwitchEquipment;
                @SwitchCharacter1.started += instance.OnSwitchCharacter1;
                @SwitchCharacter1.performed += instance.OnSwitchCharacter1;
                @SwitchCharacter1.canceled += instance.OnSwitchCharacter1;
                @SwitchCharacter2.started += instance.OnSwitchCharacter2;
                @SwitchCharacter2.performed += instance.OnSwitchCharacter2;
                @SwitchCharacter2.canceled += instance.OnSwitchCharacter2;
                @SwitchCharacter3.started += instance.OnSwitchCharacter3;
                @SwitchCharacter3.performed += instance.OnSwitchCharacter3;
                @SwitchCharacter3.canceled += instance.OnSwitchCharacter3;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSpecialButton(InputAction.CallbackContext context);
        void OnSpecialStick(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSwitchEquipment(InputAction.CallbackContext context);
        void OnSwitchCharacter1(InputAction.CallbackContext context);
        void OnSwitchCharacter2(InputAction.CallbackContext context);
        void OnSwitchCharacter3(InputAction.CallbackContext context);
    }
}
