// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/InputsController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputsController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputsController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputsController"",
    ""maps"": [
        {
            ""name"": ""Tank"",
            ""id"": ""bbce9841-85b2-4f2c-b107-c7aa45a89dfa"",
            ""actions"": [
                {
                    ""name"": ""Motion"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ebca05bf-7358-4c0a-b884-cef5cc854636"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""ca4f44c4-b868-4bbd-8114-603ddfbfc4d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecundaryFire"",
                    ""type"": ""Button"",
                    ""id"": ""35a305c9-2709-4a23-89ae-7312633b5638"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eaa4eee5-bf44-4cff-80ff-690af1cf7429"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be42d155-cf54-425d-9604-df0a179957fc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3ad8ec77-8139-417d-b516-fa1c53bd3909"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""23cf742a-8d62-4eda-b91e-f446f8f61dbb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5432e8a6-ffb7-468a-a87e-87f6c7bffd26"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""07a065c9-5a70-4668-bfc5-639041611092"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5835668c-d39f-48a5-a216-9cd1580c975e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""db352fb6-5cba-4caa-baf5-5690d52a8769"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9717e013-4ede-4e02-ab88-e830c03a1c5b"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""03f5fe46-b81b-40b2-9cca-0f45a7e1fb54"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ae123828-3738-4435-9565-5f2927d376e8"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e56d7b01-52ce-4f90-a352-662f5081bbe5"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ef53eeeb-ea17-4d7d-a5aa-c4be3a527c8c"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""SecundaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e993d3b5-5dab-49ef-95f3-0a3f88740b58"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""SecundaryFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Selection"",
            ""id"": ""4f7b5668-23d2-4398-ad47-2d31f08650e8"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""ce6c069f-1dab-473e-ab81-f69b6f0bf78b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""4c66f393-8203-41a2-b65b-80c8b5b215a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""071c5aea-6216-4aca-a660-69f263f3b4d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""d123c47c-6bcd-42c3-bf6c-fa728e75a8bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3756541a-2f7b-44f9-826d-53ddcca66570"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d383a2f6-7f5c-4325-b906-fa31cd181b2a"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edbf2783-50fb-4821-9d7f-48558e6f09db"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a63aaf9-a8ea-472c-bbe8-9cc3edc3509f"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8be0a92-5201-492d-9f65-e1cc1d688209"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""322187ae-a6a0-4323-a6b9-ac48f371cfb6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""882fed37-9ed1-47d8-9e01-a3ca7bfe8f73"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2902ea5a-9e41-439b-8e77-381e7775467f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerOne"",
            ""bindingGroup"": ""PlayerOne"",
            ""devices"": []
        },
        {
            ""name"": ""PlayerTwo"",
            ""bindingGroup"": ""PlayerTwo"",
            ""devices"": []
        }
    ]
}");
        // Tank
        m_Tank = asset.FindActionMap("Tank", throwIfNotFound: true);
        m_Tank_Motion = m_Tank.FindAction("Motion", throwIfNotFound: true);
        m_Tank_Fire = m_Tank.FindAction("Fire", throwIfNotFound: true);
        m_Tank_SecundaryFire = m_Tank.FindAction("SecundaryFire", throwIfNotFound: true);
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_Left = m_Selection.FindAction("Left", throwIfNotFound: true);
        m_Selection_Right = m_Selection.FindAction("Right", throwIfNotFound: true);
        m_Selection_Confirm = m_Selection.FindAction("Confirm", throwIfNotFound: true);
        m_Selection_Back = m_Selection.FindAction("Back", throwIfNotFound: true);
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

    // Tank
    private readonly InputActionMap m_Tank;
    private ITankActions m_TankActionsCallbackInterface;
    private readonly InputAction m_Tank_Motion;
    private readonly InputAction m_Tank_Fire;
    private readonly InputAction m_Tank_SecundaryFire;
    public struct TankActions
    {
        private @InputsController m_Wrapper;
        public TankActions(@InputsController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Motion => m_Wrapper.m_Tank_Motion;
        public InputAction @Fire => m_Wrapper.m_Tank_Fire;
        public InputAction @SecundaryFire => m_Wrapper.m_Tank_SecundaryFire;
        public InputActionMap Get() { return m_Wrapper.m_Tank; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TankActions set) { return set.Get(); }
        public void SetCallbacks(ITankActions instance)
        {
            if (m_Wrapper.m_TankActionsCallbackInterface != null)
            {
                @Motion.started -= m_Wrapper.m_TankActionsCallbackInterface.OnMotion;
                @Motion.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnMotion;
                @Motion.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnMotion;
                @Fire.started -= m_Wrapper.m_TankActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnFire;
                @SecundaryFire.started -= m_Wrapper.m_TankActionsCallbackInterface.OnSecundaryFire;
                @SecundaryFire.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnSecundaryFire;
                @SecundaryFire.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnSecundaryFire;
            }
            m_Wrapper.m_TankActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Motion.started += instance.OnMotion;
                @Motion.performed += instance.OnMotion;
                @Motion.canceled += instance.OnMotion;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @SecundaryFire.started += instance.OnSecundaryFire;
                @SecundaryFire.performed += instance.OnSecundaryFire;
                @SecundaryFire.canceled += instance.OnSecundaryFire;
            }
        }
    }
    public TankActions @Tank => new TankActions(this);

    // Selection
    private readonly InputActionMap m_Selection;
    private ISelectionActions m_SelectionActionsCallbackInterface;
    private readonly InputAction m_Selection_Left;
    private readonly InputAction m_Selection_Right;
    private readonly InputAction m_Selection_Confirm;
    private readonly InputAction m_Selection_Back;
    public struct SelectionActions
    {
        private @InputsController m_Wrapper;
        public SelectionActions(@InputsController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Selection_Left;
        public InputAction @Right => m_Wrapper.m_Selection_Right;
        public InputAction @Confirm => m_Wrapper.m_Selection_Confirm;
        public InputAction @Back => m_Wrapper.m_Selection_Back;
        public InputActionMap Get() { return m_Wrapper.m_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionActions set) { return set.Get(); }
        public void SetCallbacks(ISelectionActions instance)
        {
            if (m_Wrapper.m_SelectionActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRight;
                @Confirm.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnConfirm;
                @Back.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_SelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public SelectionActions @Selection => new SelectionActions(this);
    private int m_PlayerOneSchemeIndex = -1;
    public InputControlScheme PlayerOneScheme
    {
        get
        {
            if (m_PlayerOneSchemeIndex == -1) m_PlayerOneSchemeIndex = asset.FindControlSchemeIndex("PlayerOne");
            return asset.controlSchemes[m_PlayerOneSchemeIndex];
        }
    }
    private int m_PlayerTwoSchemeIndex = -1;
    public InputControlScheme PlayerTwoScheme
    {
        get
        {
            if (m_PlayerTwoSchemeIndex == -1) m_PlayerTwoSchemeIndex = asset.FindControlSchemeIndex("PlayerTwo");
            return asset.controlSchemes[m_PlayerTwoSchemeIndex];
        }
    }
    public interface ITankActions
    {
        void OnMotion(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSecundaryFire(InputAction.CallbackContext context);
    }
    public interface ISelectionActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
