// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Tank"",
            ""id"": ""f458399d-2dc3-4eac-a47d-1fed3de6842e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2e81575b-3f10-4021-8e15-873ba881ec41"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirePrimary"",
                    ""type"": ""Button"",
                    ""id"": ""d4cee1c5-de5f-4a14-a1e1-02914e2b7bf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireSecundary"",
                    ""type"": ""Button"",
                    ""id"": ""d894b752-95e1-415f-a307-516a81a240ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6d0750da-f179-40b8-9e10-c6bc82f4145b"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1528b45c-0339-47af-8457-312654aa49cd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3a6c10a-854c-4b4a-b9d4-28fd030d6990"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8d7bbc86-2335-496a-9cd8-fdd3fa28ade6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ac18a433-bea7-4004-b227-a235ddfa2de2"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b58e3d60-03c6-414e-8ca1-e39666e8439f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f89f46ac-07ab-4167-8c17-4396f0dd9fa1"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b0ce5b46-c4e4-4426-82c6-0277b6c7c185"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49f58093-c9b3-43c4-aa66-90a50916e922"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b501a9f8-747b-4f6b-ac7f-694a68f7bd7c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""PlayerTwo;PlayerOne"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55dd66ae-cc48-4cec-9146-4e9c1adc5368"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02235cd6-1fd9-4158-a770-45ac4451387e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""608bc3da-6d5b-4516-aec3-2eb4da8a520c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo;PlayerOne"",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbf2302a-0cd5-447e-af1b-4f16572f0399"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""FireSecundary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96fd8e42-e0d1-4ac0-93c2-feb210e4b901"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""FireSecundary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6912bf07-48c6-4ab6-b06c-51444ef3a1f9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo;PlayerOne"",
                    ""action"": ""FireSecundary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Selection"",
            ""id"": ""5df7443d-1604-479c-b8b3-cd3a9a283d22"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""541acd7c-e1b9-4658-b849-259d9417b495"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""3dbee06d-75d5-4c0a-8d49-6844d471192c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirePrimary"",
                    ""type"": ""Button"",
                    ""id"": ""457f76d7-594b-4ed9-8deb-abf5125cc769"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireSecundary"",
                    ""type"": ""Button"",
                    ""id"": ""e305abad-4584-4c05-a75e-d2a1b233644f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""53598477-67bc-478d-a75a-037f108f21a8"",
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
                    ""id"": ""d47af923-3da3-4ce0-9ec1-f13ea7a94f98"",
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
                    ""id"": ""11aa6e78-022b-45ce-87de-c7db1ee4b0f2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne;PlayerTwo"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc24fc7c-c62a-4708-8012-98efd55c7f5d"",
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
                    ""id"": ""2d10be77-8e82-4556-98e3-5d29609bc55e"",
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
                    ""id"": ""80d12594-f7f7-49cd-b382-4897b7063589"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne;PlayerTwo"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51a9078b-2adb-4fa2-8ae3-c8366f242d2d"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa0176b2-89f4-4744-8419-d066e0eaa472"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""833cdf24-2f4e-4fee-91ab-498f51e9eae5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo;PlayerOne"",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11223f2d-5b6e-4956-85fd-aff229a79a29"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerOne"",
                    ""action"": ""FireSecundary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed575740-8287-4676-ae10-c227d232e3a4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo"",
                    ""action"": ""FireSecundary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a055303d-e23b-4197-86a5-87311134295b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerTwo;PlayerOne"",
                    ""action"": ""FireSecundary"",
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
        m_Tank_Move = m_Tank.FindAction("Move", throwIfNotFound: true);
        m_Tank_FirePrimary = m_Tank.FindAction("FirePrimary", throwIfNotFound: true);
        m_Tank_FireSecundary = m_Tank.FindAction("FireSecundary", throwIfNotFound: true);
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_Left = m_Selection.FindAction("Left", throwIfNotFound: true);
        m_Selection_Right = m_Selection.FindAction("Right", throwIfNotFound: true);
        m_Selection_FirePrimary = m_Selection.FindAction("FirePrimary", throwIfNotFound: true);
        m_Selection_FireSecundary = m_Selection.FindAction("FireSecundary", throwIfNotFound: true);
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
    private readonly InputAction m_Tank_Move;
    private readonly InputAction m_Tank_FirePrimary;
    private readonly InputAction m_Tank_FireSecundary;
    public struct TankActions
    {
        private @Inputs m_Wrapper;
        public TankActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Tank_Move;
        public InputAction @FirePrimary => m_Wrapper.m_Tank_FirePrimary;
        public InputAction @FireSecundary => m_Wrapper.m_Tank_FireSecundary;
        public InputActionMap Get() { return m_Wrapper.m_Tank; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TankActions set) { return set.Get(); }
        public void SetCallbacks(ITankActions instance)
        {
            if (m_Wrapper.m_TankActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TankActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnMove;
                @FirePrimary.started -= m_Wrapper.m_TankActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnFirePrimary;
                @FireSecundary.started -= m_Wrapper.m_TankActionsCallbackInterface.OnFireSecundary;
                @FireSecundary.performed -= m_Wrapper.m_TankActionsCallbackInterface.OnFireSecundary;
                @FireSecundary.canceled -= m_Wrapper.m_TankActionsCallbackInterface.OnFireSecundary;
            }
            m_Wrapper.m_TankActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @FirePrimary.started += instance.OnFirePrimary;
                @FirePrimary.performed += instance.OnFirePrimary;
                @FirePrimary.canceled += instance.OnFirePrimary;
                @FireSecundary.started += instance.OnFireSecundary;
                @FireSecundary.performed += instance.OnFireSecundary;
                @FireSecundary.canceled += instance.OnFireSecundary;
            }
        }
    }
    public TankActions @Tank => new TankActions(this);

    // Selection
    private readonly InputActionMap m_Selection;
    private ISelectionActions m_SelectionActionsCallbackInterface;
    private readonly InputAction m_Selection_Left;
    private readonly InputAction m_Selection_Right;
    private readonly InputAction m_Selection_FirePrimary;
    private readonly InputAction m_Selection_FireSecundary;
    public struct SelectionActions
    {
        private @Inputs m_Wrapper;
        public SelectionActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Selection_Left;
        public InputAction @Right => m_Wrapper.m_Selection_Right;
        public InputAction @FirePrimary => m_Wrapper.m_Selection_FirePrimary;
        public InputAction @FireSecundary => m_Wrapper.m_Selection_FireSecundary;
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
                @FirePrimary.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnFirePrimary;
                @FireSecundary.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnFireSecundary;
                @FireSecundary.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnFireSecundary;
                @FireSecundary.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnFireSecundary;
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
                @FirePrimary.started += instance.OnFirePrimary;
                @FirePrimary.performed += instance.OnFirePrimary;
                @FirePrimary.canceled += instance.OnFirePrimary;
                @FireSecundary.started += instance.OnFireSecundary;
                @FireSecundary.performed += instance.OnFireSecundary;
                @FireSecundary.canceled += instance.OnFireSecundary;
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
        void OnMove(InputAction.CallbackContext context);
        void OnFirePrimary(InputAction.CallbackContext context);
        void OnFireSecundary(InputAction.CallbackContext context);
    }
    public interface ISelectionActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnFirePrimary(InputAction.CallbackContext context);
        void OnFireSecundary(InputAction.CallbackContext context);
    }
}
