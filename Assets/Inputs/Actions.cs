// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""PlayerOne"",
            ""id"": ""6995a6ee-f1cd-4a27-affa-8fa8af9f269e"",
            ""actions"": [
                {
                    ""name"": ""Moviment"",
                    ""type"": ""PassThrough"",
                    ""id"": ""97d64121-1aae-4966-a123-631e8d57bc3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirePrimary"",
                    ""type"": ""Button"",
                    ""id"": ""272e8030-7b52-49e8-a7e5-4d1431293f76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireSecundary"",
                    ""type"": ""Button"",
                    ""id"": ""61ecef32-1148-4a80-828e-17cd41db34c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""c9b256c3-b5e6-4894-9170-75b397d82b9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""22a4c2ed-20cf-4f70-9804-681499393f2e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""afc3cd71-092f-455e-95ac-81401ba1b928"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d78e54fb-4a63-4d07-aa97-283196252cd9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7ac55eb5-2644-4b26-a249-0e373aaf139c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aef4abc7-ff83-4eaf-9e70-49f2d7c4a3fa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2896dd36-6660-4583-aea9-c1b1cf2cdea9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7cd8b64-e756-4d9b-9b0a-671fc3c447cb"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirePrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b2dc71a-f4bc-4918-a17d-a3b2076bb38e"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireSecundary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62f22e1e-728c-42c4-a455-d4f5f7f8826d"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerTwo"",
            ""id"": ""4a82dd7f-540b-422a-850f-517a17e4b957"",
            ""actions"": [
                {
                    ""name"": ""Moviment"",
                    ""type"": ""PassThrough"",
                    ""id"": ""03c6e1e3-6d72-43ff-8be4-b61e463c4a0d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c9dcf1db-d1b9-44e5-b68d-68e2adc99716"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a5f8ab1-1e46-43c4-a31d-f6a85bb05822"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ab7927d0-18d8-4295-93ae-6c6ef2251abc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""48fa599e-0ee5-43a7-b01e-c8300fa44169"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""567bff44-1873-4837-8ca5-a2d5d4852a1f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""42c18a08-ad53-4bd6-8722-282121d9b136"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moviment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerOne
        m_PlayerOne = asset.FindActionMap("PlayerOne", throwIfNotFound: true);
        m_PlayerOne_Moviment = m_PlayerOne.FindAction("Moviment", throwIfNotFound: true);
        m_PlayerOne_FirePrimary = m_PlayerOne.FindAction("FirePrimary", throwIfNotFound: true);
        m_PlayerOne_FireSecundary = m_PlayerOne.FindAction("FireSecundary", throwIfNotFound: true);
        m_PlayerOne_Special = m_PlayerOne.FindAction("Special", throwIfNotFound: true);
        // PlayerTwo
        m_PlayerTwo = asset.FindActionMap("PlayerTwo", throwIfNotFound: true);
        m_PlayerTwo_Moviment = m_PlayerTwo.FindAction("Moviment", throwIfNotFound: true);
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

    // PlayerOne
    private readonly InputActionMap m_PlayerOne;
    private IPlayerOneActions m_PlayerOneActionsCallbackInterface;
    private readonly InputAction m_PlayerOne_Moviment;
    private readonly InputAction m_PlayerOne_FirePrimary;
    private readonly InputAction m_PlayerOne_FireSecundary;
    private readonly InputAction m_PlayerOne_Special;
    public struct PlayerOneActions
    {
        private @Actions m_Wrapper;
        public PlayerOneActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moviment => m_Wrapper.m_PlayerOne_Moviment;
        public InputAction @FirePrimary => m_Wrapper.m_PlayerOne_FirePrimary;
        public InputAction @FireSecundary => m_Wrapper.m_PlayerOne_FireSecundary;
        public InputAction @Special => m_Wrapper.m_PlayerOne_Special;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOne; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOneActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOneActions instance)
        {
            if (m_Wrapper.m_PlayerOneActionsCallbackInterface != null)
            {
                @Moviment.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoviment;
                @Moviment.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoviment;
                @Moviment.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoviment;
                @FirePrimary.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFirePrimary;
                @FirePrimary.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFirePrimary;
                @FireSecundary.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFireSecundary;
                @FireSecundary.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFireSecundary;
                @FireSecundary.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFireSecundary;
                @Special.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSpecial;
            }
            m_Wrapper.m_PlayerOneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moviment.started += instance.OnMoviment;
                @Moviment.performed += instance.OnMoviment;
                @Moviment.canceled += instance.OnMoviment;
                @FirePrimary.started += instance.OnFirePrimary;
                @FirePrimary.performed += instance.OnFirePrimary;
                @FirePrimary.canceled += instance.OnFirePrimary;
                @FireSecundary.started += instance.OnFireSecundary;
                @FireSecundary.performed += instance.OnFireSecundary;
                @FireSecundary.canceled += instance.OnFireSecundary;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);

    // PlayerTwo
    private readonly InputActionMap m_PlayerTwo;
    private IPlayerTwoActions m_PlayerTwoActionsCallbackInterface;
    private readonly InputAction m_PlayerTwo_Moviment;
    public struct PlayerTwoActions
    {
        private @Actions m_Wrapper;
        public PlayerTwoActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moviment => m_Wrapper.m_PlayerTwo_Moviment;
        public InputActionMap Get() { return m_Wrapper.m_PlayerTwo; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerTwoActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerTwoActions instance)
        {
            if (m_Wrapper.m_PlayerTwoActionsCallbackInterface != null)
            {
                @Moviment.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnMoviment;
                @Moviment.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnMoviment;
                @Moviment.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnMoviment;
            }
            m_Wrapper.m_PlayerTwoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Moviment.started += instance.OnMoviment;
                @Moviment.performed += instance.OnMoviment;
                @Moviment.canceled += instance.OnMoviment;
            }
        }
    }
    public PlayerTwoActions @PlayerTwo => new PlayerTwoActions(this);
    public interface IPlayerOneActions
    {
        void OnMoviment(InputAction.CallbackContext context);
        void OnFirePrimary(InputAction.CallbackContext context);
        void OnFireSecundary(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
    }
    public interface IPlayerTwoActions
    {
        void OnMoviment(InputAction.CallbackContext context);
    }
}
