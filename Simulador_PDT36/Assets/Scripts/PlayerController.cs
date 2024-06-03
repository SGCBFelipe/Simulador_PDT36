//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputMaps/PlayerController.inputactions
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

public partial class @PlayerController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""4255e12d-7e99-4fbf-8fbd-e0fb0aa38349"",
            ""actions"": [
                {
                    ""name"": ""KB_Right"",
                    ""type"": ""Value"",
                    ""id"": ""c5d4f519-ef9f-4efb-9522-6223ca4c50b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""KB_Left"",
                    ""type"": ""Value"",
                    ""id"": ""9d53d87b-3697-442b-8815-b9f58ba9f530"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ButtonOnOff"",
                    ""type"": ""Button"",
                    ""id"": ""5ff19634-5f30-465e-8c7a-e762ba926a96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d84c12e9-7692-4e58-818e-9bf5997f07e0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e0983f1e-a6f1-4324-b1e2-e5f02360fe29"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5b469bc8-49df-4264-881c-b79e7163f5fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c7762ef4-3bc8-4fb1-9e59-de8cee2e07e0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3a1488b3-1572-4049-9aa2-cdef2807119d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""7eabd78e-0c10-4c50-9e43-3f2a657209b1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""87c6d895-e863-4364-a09a-97e44d5a13d0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""465a46fe-546e-4707-90ff-6970590289cd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4e94c2fa-8578-492b-9aaf-d1f8819a8e5c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""75f2cfac-ad8e-4a8f-989b-4e1aec888b5f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KB_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f3c217de-b166-4cd2-9c3c-344f7a6f4e2a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonOnOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Xbox Controller"",
            ""id"": ""769e520f-deca-4c51-95c8-3518e240ae71"",
            ""actions"": [
                {
                    ""name"": ""XCTL_Left"",
                    ""type"": ""Value"",
                    ""id"": ""529acc9a-7338-4620-b3fe-cab524b66a41"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""XCTL_Right"",
                    ""type"": ""Value"",
                    ""id"": ""e28b314b-ddd0-411c-95a4-9a487f03e530"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ButtonOnOff"",
                    ""type"": ""Button"",
                    ""id"": ""a7d3d921-24ba-43df-b082-ae2bbbbcd492"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Left Stick 4 Composites"",
                    ""id"": ""7449cf01-15bd-4fbd-b536-68f57d2b65d3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84e0c83e-422b-49a9-b9fe-b8ea2493e72e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3c3f63ff-3610-4917-9b0c-fa442f62619b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""532c19bf-b850-48bc-a935-68ad82789bf5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a42f9b7c-19af-49ce-9e1c-1253cbb24ba0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a50d71eb-e20a-479f-909a-11fba463ef64"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1c25ea0-45b8-41f4-988e-66561f08c395"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Right Stick 4 Composite"",
                    ""id"": ""1cfb0449-398f-4dd8-b265-1151f35a4050"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ff63ff97-2494-437b-997c-998782f2f4fa"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b9c9ee9f-1a91-49fa-bedd-809d8c9daed2"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""314187a5-b7c5-49a8-abd4-c469b7919ffb"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1228c274-a0a8-4fbb-98fa-f0f39fb45269"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""22d55960-c5c7-464d-b4a5-08d0afc0fbe0"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7ce61fb-13b9-4703-b9e9-b6d7c2af3833"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XCTL_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6de3f0f-8024-4052-bbd8-1570bb02db88"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonOnOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fb55cca-37e5-4f43-a83b-e5cc8375abed"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonOnOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""VR Controller"",
            ""id"": ""12986ca5-28b8-4925-85a1-5801cf32acbb"",
            ""actions"": [
                {
                    ""name"": ""VR_Left"",
                    ""type"": ""Value"",
                    ""id"": ""361c83ac-aec4-4422-bb5d-5e2d570194b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""VR_Right"",
                    ""type"": ""Value"",
                    ""id"": ""6ed7b7f5-6c93-441e-9410-a906757bee05"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5415b870-2bb5-40fb-8be9-d25680f04226"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VR_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05c3b0e5-0e94-4ee0-9417-11125eb38b3f"",
                    ""path"": ""<AndroidGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VR_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a9c5635-fe99-4267-932b-f6000ed8bca6"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VR_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29c543a5-59c0-45fa-a355-fb1d4ed7bd12"",
                    ""path"": ""<AndroidGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VR_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_KB_Right = m_Keyboard.FindAction("KB_Right", throwIfNotFound: true);
        m_Keyboard_KB_Left = m_Keyboard.FindAction("KB_Left", throwIfNotFound: true);
        m_Keyboard_ButtonOnOff = m_Keyboard.FindAction("ButtonOnOff", throwIfNotFound: true);
        // Xbox Controller
        m_XboxController = asset.FindActionMap("Xbox Controller", throwIfNotFound: true);
        m_XboxController_XCTL_Left = m_XboxController.FindAction("XCTL_Left", throwIfNotFound: true);
        m_XboxController_XCTL_Right = m_XboxController.FindAction("XCTL_Right", throwIfNotFound: true);
        m_XboxController_ButtonOnOff = m_XboxController.FindAction("ButtonOnOff", throwIfNotFound: true);
        // VR Controller
        m_VRController = asset.FindActionMap("VR Controller", throwIfNotFound: true);
        m_VRController_VR_Left = m_VRController.FindAction("VR_Left", throwIfNotFound: true);
        m_VRController_VR_Right = m_VRController.FindAction("VR_Right", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private List<IKeyboardActions> m_KeyboardActionsCallbackInterfaces = new List<IKeyboardActions>();
    private readonly InputAction m_Keyboard_KB_Right;
    private readonly InputAction m_Keyboard_KB_Left;
    private readonly InputAction m_Keyboard_ButtonOnOff;
    public struct KeyboardActions
    {
        private @PlayerController m_Wrapper;
        public KeyboardActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @KB_Right => m_Wrapper.m_Keyboard_KB_Right;
        public InputAction @KB_Left => m_Wrapper.m_Keyboard_KB_Left;
        public InputAction @ButtonOnOff => m_Wrapper.m_Keyboard_ButtonOnOff;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Add(instance);
            @KB_Right.started += instance.OnKB_Right;
            @KB_Right.performed += instance.OnKB_Right;
            @KB_Right.canceled += instance.OnKB_Right;
            @KB_Left.started += instance.OnKB_Left;
            @KB_Left.performed += instance.OnKB_Left;
            @KB_Left.canceled += instance.OnKB_Left;
            @ButtonOnOff.started += instance.OnButtonOnOff;
            @ButtonOnOff.performed += instance.OnButtonOnOff;
            @ButtonOnOff.canceled += instance.OnButtonOnOff;
        }

        private void UnregisterCallbacks(IKeyboardActions instance)
        {
            @KB_Right.started -= instance.OnKB_Right;
            @KB_Right.performed -= instance.OnKB_Right;
            @KB_Right.canceled -= instance.OnKB_Right;
            @KB_Left.started -= instance.OnKB_Left;
            @KB_Left.performed -= instance.OnKB_Left;
            @KB_Left.canceled -= instance.OnKB_Left;
            @ButtonOnOff.started -= instance.OnButtonOnOff;
            @ButtonOnOff.performed -= instance.OnButtonOnOff;
            @ButtonOnOff.canceled -= instance.OnButtonOnOff;
        }

        public void RemoveCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);

    // Xbox Controller
    private readonly InputActionMap m_XboxController;
    private List<IXboxControllerActions> m_XboxControllerActionsCallbackInterfaces = new List<IXboxControllerActions>();
    private readonly InputAction m_XboxController_XCTL_Left;
    private readonly InputAction m_XboxController_XCTL_Right;
    private readonly InputAction m_XboxController_ButtonOnOff;
    public struct XboxControllerActions
    {
        private @PlayerController m_Wrapper;
        public XboxControllerActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @XCTL_Left => m_Wrapper.m_XboxController_XCTL_Left;
        public InputAction @XCTL_Right => m_Wrapper.m_XboxController_XCTL_Right;
        public InputAction @ButtonOnOff => m_Wrapper.m_XboxController_ButtonOnOff;
        public InputActionMap Get() { return m_Wrapper.m_XboxController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XboxControllerActions set) { return set.Get(); }
        public void AddCallbacks(IXboxControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_XboxControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_XboxControllerActionsCallbackInterfaces.Add(instance);
            @XCTL_Left.started += instance.OnXCTL_Left;
            @XCTL_Left.performed += instance.OnXCTL_Left;
            @XCTL_Left.canceled += instance.OnXCTL_Left;
            @XCTL_Right.started += instance.OnXCTL_Right;
            @XCTL_Right.performed += instance.OnXCTL_Right;
            @XCTL_Right.canceled += instance.OnXCTL_Right;
            @ButtonOnOff.started += instance.OnButtonOnOff;
            @ButtonOnOff.performed += instance.OnButtonOnOff;
            @ButtonOnOff.canceled += instance.OnButtonOnOff;
        }

        private void UnregisterCallbacks(IXboxControllerActions instance)
        {
            @XCTL_Left.started -= instance.OnXCTL_Left;
            @XCTL_Left.performed -= instance.OnXCTL_Left;
            @XCTL_Left.canceled -= instance.OnXCTL_Left;
            @XCTL_Right.started -= instance.OnXCTL_Right;
            @XCTL_Right.performed -= instance.OnXCTL_Right;
            @XCTL_Right.canceled -= instance.OnXCTL_Right;
            @ButtonOnOff.started -= instance.OnButtonOnOff;
            @ButtonOnOff.performed -= instance.OnButtonOnOff;
            @ButtonOnOff.canceled -= instance.OnButtonOnOff;
        }

        public void RemoveCallbacks(IXboxControllerActions instance)
        {
            if (m_Wrapper.m_XboxControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IXboxControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_XboxControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_XboxControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public XboxControllerActions @XboxController => new XboxControllerActions(this);

    // VR Controller
    private readonly InputActionMap m_VRController;
    private List<IVRControllerActions> m_VRControllerActionsCallbackInterfaces = new List<IVRControllerActions>();
    private readonly InputAction m_VRController_VR_Left;
    private readonly InputAction m_VRController_VR_Right;
    public struct VRControllerActions
    {
        private @PlayerController m_Wrapper;
        public VRControllerActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @VR_Left => m_Wrapper.m_VRController_VR_Left;
        public InputAction @VR_Right => m_Wrapper.m_VRController_VR_Right;
        public InputActionMap Get() { return m_Wrapper.m_VRController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VRControllerActions set) { return set.Get(); }
        public void AddCallbacks(IVRControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_VRControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_VRControllerActionsCallbackInterfaces.Add(instance);
            @VR_Left.started += instance.OnVR_Left;
            @VR_Left.performed += instance.OnVR_Left;
            @VR_Left.canceled += instance.OnVR_Left;
            @VR_Right.started += instance.OnVR_Right;
            @VR_Right.performed += instance.OnVR_Right;
            @VR_Right.canceled += instance.OnVR_Right;
        }

        private void UnregisterCallbacks(IVRControllerActions instance)
        {
            @VR_Left.started -= instance.OnVR_Left;
            @VR_Left.performed -= instance.OnVR_Left;
            @VR_Left.canceled -= instance.OnVR_Left;
            @VR_Right.started -= instance.OnVR_Right;
            @VR_Right.performed -= instance.OnVR_Right;
            @VR_Right.canceled -= instance.OnVR_Right;
        }

        public void RemoveCallbacks(IVRControllerActions instance)
        {
            if (m_Wrapper.m_VRControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IVRControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_VRControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_VRControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public VRControllerActions @VRController => new VRControllerActions(this);
    public interface IKeyboardActions
    {
        void OnKB_Right(InputAction.CallbackContext context);
        void OnKB_Left(InputAction.CallbackContext context);
        void OnButtonOnOff(InputAction.CallbackContext context);
    }
    public interface IXboxControllerActions
    {
        void OnXCTL_Left(InputAction.CallbackContext context);
        void OnXCTL_Right(InputAction.CallbackContext context);
        void OnButtonOnOff(InputAction.CallbackContext context);
    }
    public interface IVRControllerActions
    {
        void OnVR_Left(InputAction.CallbackContext context);
        void OnVR_Right(InputAction.CallbackContext context);
    }
}
