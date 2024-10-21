//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/_CUSTOM_ASSETS/_ABACUS_RaiderSwarm/Actions/RSPlayerInputActions.inputactions
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

public partial class @RSPlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @RSPlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RSPlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""RSPlayer"",
            ""id"": ""8d43106e-703a-4cc7-9155-3cd6ec96526f"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""02b0ce64-37b3-4983-838c-90606c5a9b33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""afc15d97-c0cc-4cab-a6a6-ea7a7d5de02b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""19b7f456-106e-47aa-b856-240566a8398b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""856d4882-e63f-4b37-99c4-7a321794d4f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""26dc334b-7eeb-4815-9629-adfc2f8c4a2e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""7504d4e4-0838-4753-915a-86c465406f2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cfe0428b-f824-4c1d-93de-e811235a7dda"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d124edb-b2b4-4a6b-92f0-4495c958f490"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2658874-356a-4a6c-9413-2b3b972dc6e5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42e22e33-a0d0-44b9-a107-8e1cfaac6972"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3edb5c88-1def-4eff-8be2-57dd6324e262"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1560939-bb22-4203-8757-0b71c8b75e47"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8faf0b6e-8cd1-43be-9b5b-f297a7a362ec"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6c33c22-c710-4418-b0e2-2f726297d131"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6a1e525-64a4-4665-8a2b-8c7d9f6e7aef"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a48e9b9a-8840-41c4-8a35-fce6a55ca109"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38061044-43ee-47d2-af08-8dd8c5e1d18d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3301a214-0416-4e30-b392-953cf07c8839"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41172105-9b6b-488a-b859-d3e70993fba3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b903d00-adfb-4f75-8c41-4dc92bfd632d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ab0674b-5602-437b-a4f9-1847f5049c14"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f37a799b-3cbc-420a-ac85-ac1f8472407a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""de11d4ed-abcb-43d8-81c0-11c639564227"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""623e43dd-739f-4954-8e35-3c2fbfb488c0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b3d1e937-4574-452f-904d-9e23b7967ae3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""908e15c7-9589-4928-8b1b-7c79fd7e0dd9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""858790d5-3cb0-455b-8940-337975f0775a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b82a4f22-75a6-4cc5-a178-ae2f732933d6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""4af387b8-f100-439e-968b-6188181c62be"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eae1d38b-0b14-402a-8329-3ce082f90496"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4e71ce09-09c8-4c7b-86ae-85c525de2aa9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1a19d3fb-7f25-42da-9871-154d9dcc2add"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b37a760b-6dfe-4a92-b432-ba9918c702d7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""3ebce176-6b79-45f1-8fd5-7bbd57acc97c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""92f76b7c-b42b-4059-b3c0-3e5471bad716"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""95c241c7-1e84-48dc-a900-2b9f1f42cfa1"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""973ca43b-ea0d-4da3-a914-4f96fa7383b7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9205d031-2e6f-4b14-9404-c17e883ea015"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bf690d0f-4a56-4356-b1d5-94240bd4de0b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ac2e37f-eaf1-4d05-af80-872e6b924e97"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RSUI"",
            ""id"": ""fae7b557-ade2-41f9-ac1d-981bf739ed11"",
            ""actions"": [
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""2bc0bfd3-794d-4a3f-a3d2-453b9ec9ae19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""da898936-e2ab-470f-874b-e84fd1ecde96"",
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
                    ""id"": ""acb995c5-616a-46f0-9d59-c49bf9e15e6f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RSPlayer
        m_RSPlayer = asset.FindActionMap("RSPlayer", throwIfNotFound: true);
        m_RSPlayer_Left = m_RSPlayer.FindAction("Left", throwIfNotFound: true);
        m_RSPlayer_Right = m_RSPlayer.FindAction("Right", throwIfNotFound: true);
        m_RSPlayer_PrimaryFire = m_RSPlayer.FindAction("PrimaryFire", throwIfNotFound: true);
        m_RSPlayer_SecondaryFire = m_RSPlayer.FindAction("SecondaryFire", throwIfNotFound: true);
        m_RSPlayer_Move = m_RSPlayer.FindAction("Move", throwIfNotFound: true);
        m_RSPlayer_Restart = m_RSPlayer.FindAction("Restart", throwIfNotFound: true);
        // RSUI
        m_RSUI = asset.FindActionMap("RSUI", throwIfNotFound: true);
        m_RSUI_Accept = m_RSUI.FindAction("Accept", throwIfNotFound: true);
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

    // RSPlayer
    private readonly InputActionMap m_RSPlayer;
    private List<IRSPlayerActions> m_RSPlayerActionsCallbackInterfaces = new List<IRSPlayerActions>();
    private readonly InputAction m_RSPlayer_Left;
    private readonly InputAction m_RSPlayer_Right;
    private readonly InputAction m_RSPlayer_PrimaryFire;
    private readonly InputAction m_RSPlayer_SecondaryFire;
    private readonly InputAction m_RSPlayer_Move;
    private readonly InputAction m_RSPlayer_Restart;
    public struct RSPlayerActions
    {
        private @RSPlayerInputActions m_Wrapper;
        public RSPlayerActions(@RSPlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_RSPlayer_Left;
        public InputAction @Right => m_Wrapper.m_RSPlayer_Right;
        public InputAction @PrimaryFire => m_Wrapper.m_RSPlayer_PrimaryFire;
        public InputAction @SecondaryFire => m_Wrapper.m_RSPlayer_SecondaryFire;
        public InputAction @Move => m_Wrapper.m_RSPlayer_Move;
        public InputAction @Restart => m_Wrapper.m_RSPlayer_Restart;
        public InputActionMap Get() { return m_Wrapper.m_RSPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RSPlayerActions set) { return set.Get(); }
        public void AddCallbacks(IRSPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_RSPlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RSPlayerActionsCallbackInterfaces.Add(instance);
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @Right.started += instance.OnRight;
            @Right.performed += instance.OnRight;
            @Right.canceled += instance.OnRight;
            @PrimaryFire.started += instance.OnPrimaryFire;
            @PrimaryFire.performed += instance.OnPrimaryFire;
            @PrimaryFire.canceled += instance.OnPrimaryFire;
            @SecondaryFire.started += instance.OnSecondaryFire;
            @SecondaryFire.performed += instance.OnSecondaryFire;
            @SecondaryFire.canceled += instance.OnSecondaryFire;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Restart.started += instance.OnRestart;
            @Restart.performed += instance.OnRestart;
            @Restart.canceled += instance.OnRestart;
        }

        private void UnregisterCallbacks(IRSPlayerActions instance)
        {
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @Right.started -= instance.OnRight;
            @Right.performed -= instance.OnRight;
            @Right.canceled -= instance.OnRight;
            @PrimaryFire.started -= instance.OnPrimaryFire;
            @PrimaryFire.performed -= instance.OnPrimaryFire;
            @PrimaryFire.canceled -= instance.OnPrimaryFire;
            @SecondaryFire.started -= instance.OnSecondaryFire;
            @SecondaryFire.performed -= instance.OnSecondaryFire;
            @SecondaryFire.canceled -= instance.OnSecondaryFire;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Restart.started -= instance.OnRestart;
            @Restart.performed -= instance.OnRestart;
            @Restart.canceled -= instance.OnRestart;
        }

        public void RemoveCallbacks(IRSPlayerActions instance)
        {
            if (m_Wrapper.m_RSPlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRSPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_RSPlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RSPlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RSPlayerActions @RSPlayer => new RSPlayerActions(this);

    // RSUI
    private readonly InputActionMap m_RSUI;
    private List<IRSUIActions> m_RSUIActionsCallbackInterfaces = new List<IRSUIActions>();
    private readonly InputAction m_RSUI_Accept;
    public struct RSUIActions
    {
        private @RSPlayerInputActions m_Wrapper;
        public RSUIActions(@RSPlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accept => m_Wrapper.m_RSUI_Accept;
        public InputActionMap Get() { return m_Wrapper.m_RSUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RSUIActions set) { return set.Get(); }
        public void AddCallbacks(IRSUIActions instance)
        {
            if (instance == null || m_Wrapper.m_RSUIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RSUIActionsCallbackInterfaces.Add(instance);
            @Accept.started += instance.OnAccept;
            @Accept.performed += instance.OnAccept;
            @Accept.canceled += instance.OnAccept;
        }

        private void UnregisterCallbacks(IRSUIActions instance)
        {
            @Accept.started -= instance.OnAccept;
            @Accept.performed -= instance.OnAccept;
            @Accept.canceled -= instance.OnAccept;
        }

        public void RemoveCallbacks(IRSUIActions instance)
        {
            if (m_Wrapper.m_RSUIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRSUIActions instance)
        {
            foreach (var item in m_Wrapper.m_RSUIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RSUIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RSUIActions @RSUI => new RSUIActions(this);
    public interface IRSPlayerActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnPrimaryFire(InputAction.CallbackContext context);
        void OnSecondaryFire(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
    public interface IRSUIActions
    {
        void OnAccept(InputAction.CallbackContext context);
    }
}
