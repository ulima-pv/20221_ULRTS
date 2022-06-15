//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputActions/PlayerInputActions.inputactions
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
            ""id"": ""39a12079-6239-4fd3-abcf-81e7468f67ac"",
            ""actions"": [
                {
                    ""name"": ""MouseSelect"",
                    ""type"": ""Button"",
                    ""id"": ""cd3cbed7-3a2b-472f-a641-eac5bf6399a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseMovement"",
                    ""type"": ""Value"",
                    ""id"": ""17b92df3-792f-43b9-a9e5-531b91f9a177"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TabPressed"",
                    ""type"": ""Button"",
                    ""id"": ""f3a6e70e-cb0c-4599-a542-db5185980afb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6162c81e-5f7e-4f2c-bd62-ba4d5c84780a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87745b8f-4bc0-4939-9c89-757a840ae828"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8a0efcd-d7dc-419d-83d3-111fd7c3d398"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TabPressed"",
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
        m_Player_MouseSelect = m_Player.FindAction("MouseSelect", throwIfNotFound: true);
        m_Player_MouseMovement = m_Player.FindAction("MouseMovement", throwIfNotFound: true);
        m_Player_TabPressed = m_Player.FindAction("TabPressed", throwIfNotFound: true);
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
    private readonly InputAction m_Player_MouseSelect;
    private readonly InputAction m_Player_MouseMovement;
    private readonly InputAction m_Player_TabPressed;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseSelect => m_Wrapper.m_Player_MouseSelect;
        public InputAction @MouseMovement => m_Wrapper.m_Player_MouseMovement;
        public InputAction @TabPressed => m_Wrapper.m_Player_TabPressed;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MouseSelect.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseSelect;
                @MouseSelect.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseSelect;
                @MouseSelect.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseSelect;
                @MouseMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMovement;
                @TabPressed.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTabPressed;
                @TabPressed.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTabPressed;
                @TabPressed.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTabPressed;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseSelect.started += instance.OnMouseSelect;
                @MouseSelect.performed += instance.OnMouseSelect;
                @MouseSelect.canceled += instance.OnMouseSelect;
                @MouseMovement.started += instance.OnMouseMovement;
                @MouseMovement.performed += instance.OnMouseMovement;
                @MouseMovement.canceled += instance.OnMouseMovement;
                @TabPressed.started += instance.OnTabPressed;
                @TabPressed.performed += instance.OnTabPressed;
                @TabPressed.canceled += instance.OnTabPressed;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMouseSelect(InputAction.CallbackContext context);
        void OnMouseMovement(InputAction.CallbackContext context);
        void OnTabPressed(InputAction.CallbackContext context);
    }
}