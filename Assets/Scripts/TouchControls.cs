//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/TouchControls.inputactions
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

public partial class @TouchControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Pinch to Zoom"",
            ""id"": ""1fb9174a-969f-459b-9c1c-637b2050aa5b"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""0b98d4b0-7cc9-431f-9b6d-8de00072391d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""b2c2abf8-6357-4d3b-a9c4-f474eba24a88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""12a869e4-e7e2-41bc-9602-3400e0a66617"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cdc5d75c-a3e7-43d3-8fd0-51cec15a3f17"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9a85919-e55a-4304-8fb4-065b0aa3e08b"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f637707b-bb05-42d5-8e7a-2a1a866f56dd"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Click"",
            ""id"": ""d2451b63-4f8d-45ef-b862-94b9b8f45939"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFingerClicked"",
                    ""type"": ""Button"",
                    ""id"": ""fca834dc-bf4f-48d2-84fb-f5821be982ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""dbd6c655-2688-45f1-aa64-4b8c7e1e4dfa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a881f9eb-1c45-43fd-9067-058c76a0ff0a"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerClicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""465bb2db-9168-4a64-aa5a-5737c474aaba"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerClicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""025677d9-9165-45d1-8d93-b72c8bd0d132"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""978e54ae-bf2f-4208-bb5a-24959738fbb1"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pan"",
            ""id"": ""5fb5b830-9a03-4ad7-8160-ed4ffd8df778"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFingerTouch"",
                    ""type"": ""Button"",
                    ""id"": ""d2230c7d-fdb6-4e8c-a625-58d116c522fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""2ae61d67-31da-4db4-b74c-c03ed4f9053d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryFingerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""090bbd69-9a37-4753-ad98-ea33da63884f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b191086-aca6-4e2d-9113-0095f5905bad"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d45e8a4-86b9-48f1-83f3-83d39e40359f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""112e43ca-0468-4447-9e41-5c1ad288b10a"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bed25a4-61cf-45f5-81dd-2b9337f6e6c8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b58498cc-5888-4f0e-82f7-1947fbab79e1"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Pinch to Zoom
        m_PinchtoZoom = asset.FindActionMap("Pinch to Zoom", throwIfNotFound: true);
        m_PinchtoZoom_PrimaryFingerPosition = m_PinchtoZoom.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
        m_PinchtoZoom_SecondaryTouchContact = m_PinchtoZoom.FindAction("SecondaryTouchContact", throwIfNotFound: true);
        m_PinchtoZoom_SecondaryFingerPosition = m_PinchtoZoom.FindAction("SecondaryFingerPosition", throwIfNotFound: true);
        // Click
        m_Click = asset.FindActionMap("Click", throwIfNotFound: true);
        m_Click_PrimaryFingerClicked = m_Click.FindAction("PrimaryFingerClicked", throwIfNotFound: true);
        m_Click_PrimaryFingerPosition = m_Click.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
        // Pan
        m_Pan = asset.FindActionMap("Pan", throwIfNotFound: true);
        m_Pan_PrimaryFingerTouch = m_Pan.FindAction("PrimaryFingerTouch", throwIfNotFound: true);
        m_Pan_SecondaryTouchContact = m_Pan.FindAction("SecondaryTouchContact", throwIfNotFound: true);
        m_Pan_PrimaryFingerPosition = m_Pan.FindAction("PrimaryFingerPosition", throwIfNotFound: true);
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

    // Pinch to Zoom
    private readonly InputActionMap m_PinchtoZoom;
    private IPinchtoZoomActions m_PinchtoZoomActionsCallbackInterface;
    private readonly InputAction m_PinchtoZoom_PrimaryFingerPosition;
    private readonly InputAction m_PinchtoZoom_SecondaryTouchContact;
    private readonly InputAction m_PinchtoZoom_SecondaryFingerPosition;
    public struct PinchtoZoomActions
    {
        private @TouchControls m_Wrapper;
        public PinchtoZoomActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFingerPosition => m_Wrapper.m_PinchtoZoom_PrimaryFingerPosition;
        public InputAction @SecondaryTouchContact => m_Wrapper.m_PinchtoZoom_SecondaryTouchContact;
        public InputAction @SecondaryFingerPosition => m_Wrapper.m_PinchtoZoom_SecondaryFingerPosition;
        public InputActionMap Get() { return m_Wrapper.m_PinchtoZoom; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PinchtoZoomActions set) { return set.Get(); }
        public void SetCallbacks(IPinchtoZoomActions instance)
        {
            if (m_Wrapper.m_PinchtoZoomActionsCallbackInterface != null)
            {
                @PrimaryFingerPosition.started -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnPrimaryFingerPosition;
                @SecondaryTouchContact.started -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryFingerPosition.started -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.performed -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.canceled -= m_Wrapper.m_PinchtoZoomActionsCallbackInterface.OnSecondaryFingerPosition;
            }
            m_Wrapper.m_PinchtoZoomActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryFingerPosition.started += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled += instance.OnPrimaryFingerPosition;
                @SecondaryTouchContact.started += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled += instance.OnSecondaryTouchContact;
                @SecondaryFingerPosition.started += instance.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.performed += instance.OnSecondaryFingerPosition;
                @SecondaryFingerPosition.canceled += instance.OnSecondaryFingerPosition;
            }
        }
    }
    public PinchtoZoomActions @PinchtoZoom => new PinchtoZoomActions(this);

    // Click
    private readonly InputActionMap m_Click;
    private IClickActions m_ClickActionsCallbackInterface;
    private readonly InputAction m_Click_PrimaryFingerClicked;
    private readonly InputAction m_Click_PrimaryFingerPosition;
    public struct ClickActions
    {
        private @TouchControls m_Wrapper;
        public ClickActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFingerClicked => m_Wrapper.m_Click_PrimaryFingerClicked;
        public InputAction @PrimaryFingerPosition => m_Wrapper.m_Click_PrimaryFingerPosition;
        public InputActionMap Get() { return m_Wrapper.m_Click; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClickActions set) { return set.Get(); }
        public void SetCallbacks(IClickActions instance)
        {
            if (m_Wrapper.m_ClickActionsCallbackInterface != null)
            {
                @PrimaryFingerClicked.started -= m_Wrapper.m_ClickActionsCallbackInterface.OnPrimaryFingerClicked;
                @PrimaryFingerClicked.performed -= m_Wrapper.m_ClickActionsCallbackInterface.OnPrimaryFingerClicked;
                @PrimaryFingerClicked.canceled -= m_Wrapper.m_ClickActionsCallbackInterface.OnPrimaryFingerClicked;
                @PrimaryFingerPosition.started -= m_Wrapper.m_ClickActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed -= m_Wrapper.m_ClickActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled -= m_Wrapper.m_ClickActionsCallbackInterface.OnPrimaryFingerPosition;
            }
            m_Wrapper.m_ClickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryFingerClicked.started += instance.OnPrimaryFingerClicked;
                @PrimaryFingerClicked.performed += instance.OnPrimaryFingerClicked;
                @PrimaryFingerClicked.canceled += instance.OnPrimaryFingerClicked;
                @PrimaryFingerPosition.started += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled += instance.OnPrimaryFingerPosition;
            }
        }
    }
    public ClickActions @Click => new ClickActions(this);

    // Pan
    private readonly InputActionMap m_Pan;
    private IPanActions m_PanActionsCallbackInterface;
    private readonly InputAction m_Pan_PrimaryFingerTouch;
    private readonly InputAction m_Pan_SecondaryTouchContact;
    private readonly InputAction m_Pan_PrimaryFingerPosition;
    public struct PanActions
    {
        private @TouchControls m_Wrapper;
        public PanActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFingerTouch => m_Wrapper.m_Pan_PrimaryFingerTouch;
        public InputAction @SecondaryTouchContact => m_Wrapper.m_Pan_SecondaryTouchContact;
        public InputAction @PrimaryFingerPosition => m_Wrapper.m_Pan_PrimaryFingerPosition;
        public InputActionMap Get() { return m_Wrapper.m_Pan; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PanActions set) { return set.Get(); }
        public void SetCallbacks(IPanActions instance)
        {
            if (m_Wrapper.m_PanActionsCallbackInterface != null)
            {
                @PrimaryFingerTouch.started -= m_Wrapper.m_PanActionsCallbackInterface.OnPrimaryFingerTouch;
                @PrimaryFingerTouch.performed -= m_Wrapper.m_PanActionsCallbackInterface.OnPrimaryFingerTouch;
                @PrimaryFingerTouch.canceled -= m_Wrapper.m_PanActionsCallbackInterface.OnPrimaryFingerTouch;
                @SecondaryTouchContact.started -= m_Wrapper.m_PanActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed -= m_Wrapper.m_PanActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled -= m_Wrapper.m_PanActionsCallbackInterface.OnSecondaryTouchContact;
                @PrimaryFingerPosition.started -= m_Wrapper.m_PanActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed -= m_Wrapper.m_PanActionsCallbackInterface.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled -= m_Wrapper.m_PanActionsCallbackInterface.OnPrimaryFingerPosition;
            }
            m_Wrapper.m_PanActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryFingerTouch.started += instance.OnPrimaryFingerTouch;
                @PrimaryFingerTouch.performed += instance.OnPrimaryFingerTouch;
                @PrimaryFingerTouch.canceled += instance.OnPrimaryFingerTouch;
                @SecondaryTouchContact.started += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled += instance.OnSecondaryTouchContact;
                @PrimaryFingerPosition.started += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.performed += instance.OnPrimaryFingerPosition;
                @PrimaryFingerPosition.canceled += instance.OnPrimaryFingerPosition;
            }
        }
    }
    public PanActions @Pan => new PanActions(this);
    public interface IPinchtoZoomActions
    {
        void OnPrimaryFingerPosition(InputAction.CallbackContext context);
        void OnSecondaryTouchContact(InputAction.CallbackContext context);
        void OnSecondaryFingerPosition(InputAction.CallbackContext context);
    }
    public interface IClickActions
    {
        void OnPrimaryFingerClicked(InputAction.CallbackContext context);
        void OnPrimaryFingerPosition(InputAction.CallbackContext context);
    }
    public interface IPanActions
    {
        void OnPrimaryFingerTouch(InputAction.CallbackContext context);
        void OnSecondaryTouchContact(InputAction.CallbackContext context);
        void OnPrimaryFingerPosition(InputAction.CallbackContext context);
    }
}
