// GENERATED AUTOMATICALLY FROM 'Assets/scripts/inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""charecter"",
            ""id"": ""5e7323a9-3962-4737-939d-1ce73cef7cef"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""cd84388c-1e60-406f-bdc5-4bbd4939865c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""b2c0d5cd-5b81-4266-98d9-626587315a39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeItem"",
                    ""type"": ""Button"",
                    ""id"": ""bab5635a-d881-459e-9ee1-eb7ce7a9519f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a484488e-a632-49bb-b245-500bf27d74d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""37a3a254-e672-4bd5-b8fb-0fbc832ca6b6"",
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
                    ""id"": ""c1f1e5bd-e292-4f24-a6e0-3499837d73c9"",
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
                    ""id"": ""7800c886-831a-4d18-90e9-42ff159c6f5b"",
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
                    ""id"": ""efec0a51-6d68-4c01-85f8-5e5fb1b65bf8"",
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
                    ""id"": ""b01aa36c-01bd-42a4-a677-f9535f5a4e08"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""92919c90-285e-4412-b5fb-7755c8ca71da"",
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
                    ""id"": ""3cd49864-9c99-45b3-a8dc-fd3f76913526"",
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
                    ""id"": ""33100559-7886-4087-969e-64926b4c2350"",
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
                    ""id"": ""edd39369-a499-4372-9d5b-3c8afdf6a7d5"",
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
                    ""id"": ""f5f48e57-6f67-4103-ab49-4208c0348e65"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1df2579d-cc15-4d39-993d-88ab4cdb5009"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ER"",
                    ""id"": ""60d84058-23c9-445e-b5ef-b4c683773f53"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeItem"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bb885e66-5954-4395-9d59-57c412200dd0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""74328ad3-e775-4580-b5bd-b6163dd34cc2"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""71ed7051-015b-4e4e-b9e6-c3869afff9b2"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // charecter
        m_charecter = asset.FindActionMap("charecter", throwIfNotFound: true);
        m_charecter_Move = m_charecter.FindAction("Move", throwIfNotFound: true);
        m_charecter_Use = m_charecter.FindAction("Use", throwIfNotFound: true);
        m_charecter_ChangeItem = m_charecter.FindAction("ChangeItem", throwIfNotFound: true);
        m_charecter_Interact = m_charecter.FindAction("Interact", throwIfNotFound: true);
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

    // charecter
    private readonly InputActionMap m_charecter;
    private ICharecterActions m_CharecterActionsCallbackInterface;
    private readonly InputAction m_charecter_Move;
    private readonly InputAction m_charecter_Use;
    private readonly InputAction m_charecter_ChangeItem;
    private readonly InputAction m_charecter_Interact;
    public struct CharecterActions
    {
        private @Controls m_Wrapper;
        public CharecterActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_charecter_Move;
        public InputAction @Use => m_Wrapper.m_charecter_Use;
        public InputAction @ChangeItem => m_Wrapper.m_charecter_ChangeItem;
        public InputAction @Interact => m_Wrapper.m_charecter_Interact;
        public InputActionMap Get() { return m_Wrapper.m_charecter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharecterActions set) { return set.Get(); }
        public void SetCallbacks(ICharecterActions instance)
        {
            if (m_Wrapper.m_CharecterActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharecterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharecterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharecterActionsCallbackInterface.OnMove;
                @Use.started -= m_Wrapper.m_CharecterActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_CharecterActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_CharecterActionsCallbackInterface.OnUse;
                @ChangeItem.started -= m_Wrapper.m_CharecterActionsCallbackInterface.OnChangeItem;
                @ChangeItem.performed -= m_Wrapper.m_CharecterActionsCallbackInterface.OnChangeItem;
                @ChangeItem.canceled -= m_Wrapper.m_CharecterActionsCallbackInterface.OnChangeItem;
                @Interact.started -= m_Wrapper.m_CharecterActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CharecterActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CharecterActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_CharecterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @ChangeItem.started += instance.OnChangeItem;
                @ChangeItem.performed += instance.OnChangeItem;
                @ChangeItem.canceled += instance.OnChangeItem;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public CharecterActions @charecter => new CharecterActions(this);
    public interface ICharecterActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnChangeItem(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
