// GENERATED AUTOMATICALLY FROM 'Assets/player/scripts/playerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerControls"",
    ""maps"": [
        {
            ""name"": ""normal"",
            ""id"": ""9f7e09d2-0426-4410-824d-e9bb31c71b2d"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""ce33b729-ddae-408f-bc63-66df48acd3da"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""0898ea67-6562-4357-b5cf-2d5f3226b493"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""roll"",
                    ""type"": ""Button"",
                    ""id"": ""296a60eb-fed6-4889-a16c-ea3936d94553"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""21da8cf7-34a8-4867-8f43-9ef3af5e24f7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""item_use"",
                    ""type"": ""Button"",
                    ""id"": ""741a7931-d64d-4d33-afda-62c0df23ecbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""menu"",
                    ""type"": ""Button"",
                    ""id"": ""b4120524-fd24-4fc5-8cd2-571928a283cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""sprint"",
                    ""type"": ""Button"",
                    ""id"": ""b82a70bc-83fd-44d2-b9c5-bd425da0359e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a7848f6c-ceda-495b-bc8f-df28e1cc3fe1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f60b6122-6900-469b-af7c-ed79681bf405"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""893a90a9-e09d-40ca-a91a-76f9600a5ac5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5612aa4b-8680-48f8-a28b-532a78499712"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bc60ea57-cb86-4d81-be22-e9dd6e83d852"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5fe806d2-30f4-4e19-8c17-1944cc7d8a22"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d66afb39-c381-438d-8b36-c075440c2046"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3325df75-e8f4-458a-bb25-1ca3eeb5f630"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2147dfa-52ac-44e7-902f-5124a149476f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa50c126-00e2-44af-bffb-043e369c13d3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13a57d23-f985-40cc-a9d5-aa40baa11200"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2"",
                    ""groups"": ""keeb"",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20db01a5-0629-4db8-b0ad-55dd48a164a3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertY=false)"",
                    ""groups"": ""controller"",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cd06799-5e19-4e5b-a90d-741964ad6331"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""item_use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b10e493-31ed-421c-9e49-0683cc56074e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""item_use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01cead5b-3124-46c0-ac02-e3f16a99a10b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbf2665b-190f-4b05-9235-b12b62f30ddb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""532cf680-534c-4f42-85b2-98906e44e3ad"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""controller"",
                    ""action"": ""sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1ac3b34-3d92-4789-91aa-513725960b8d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keeb"",
                    ""action"": ""sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keeb"",
            ""bindingGroup"": ""keeb"",
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
            ""name"": ""controller"",
            ""bindingGroup"": ""controller"",
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
        // normal
        m_normal = asset.FindActionMap("normal", throwIfNotFound: true);
        m_normal_move = m_normal.FindAction("move", throwIfNotFound: true);
        m_normal_Action = m_normal.FindAction("Action", throwIfNotFound: true);
        m_normal_roll = m_normal.FindAction("roll", throwIfNotFound: true);
        m_normal_look = m_normal.FindAction("look", throwIfNotFound: true);
        m_normal_item_use = m_normal.FindAction("item_use", throwIfNotFound: true);
        m_normal_menu = m_normal.FindAction("menu", throwIfNotFound: true);
        m_normal_sprint = m_normal.FindAction("sprint", throwIfNotFound: true);
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

    // normal
    private readonly InputActionMap m_normal;
    private INormalActions m_NormalActionsCallbackInterface;
    private readonly InputAction m_normal_move;
    private readonly InputAction m_normal_Action;
    private readonly InputAction m_normal_roll;
    private readonly InputAction m_normal_look;
    private readonly InputAction m_normal_item_use;
    private readonly InputAction m_normal_menu;
    private readonly InputAction m_normal_sprint;
    public struct NormalActions
    {
        private @PlayerControls m_Wrapper;
        public NormalActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_normal_move;
        public InputAction @Action => m_Wrapper.m_normal_Action;
        public InputAction @roll => m_Wrapper.m_normal_roll;
        public InputAction @look => m_Wrapper.m_normal_look;
        public InputAction @item_use => m_Wrapper.m_normal_item_use;
        public InputAction @menu => m_Wrapper.m_normal_menu;
        public InputAction @sprint => m_Wrapper.m_normal_sprint;
        public InputActionMap Get() { return m_Wrapper.m_normal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NormalActions set) { return set.Get(); }
        public void SetCallbacks(INormalActions instance)
        {
            if (m_Wrapper.m_NormalActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnMove;
                @Action.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnAction;
                @roll.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnRoll;
                @roll.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnRoll;
                @roll.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnRoll;
                @look.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnLook;
                @look.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnLook;
                @look.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnLook;
                @item_use.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnItem_use;
                @item_use.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnItem_use;
                @item_use.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnItem_use;
                @menu.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnMenu;
                @menu.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnMenu;
                @menu.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnMenu;
                @sprint.started -= m_Wrapper.m_NormalActionsCallbackInterface.OnSprint;
                @sprint.performed -= m_Wrapper.m_NormalActionsCallbackInterface.OnSprint;
                @sprint.canceled -= m_Wrapper.m_NormalActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_NormalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @roll.started += instance.OnRoll;
                @roll.performed += instance.OnRoll;
                @roll.canceled += instance.OnRoll;
                @look.started += instance.OnLook;
                @look.performed += instance.OnLook;
                @look.canceled += instance.OnLook;
                @item_use.started += instance.OnItem_use;
                @item_use.performed += instance.OnItem_use;
                @item_use.canceled += instance.OnItem_use;
                @menu.started += instance.OnMenu;
                @menu.performed += instance.OnMenu;
                @menu.canceled += instance.OnMenu;
                @sprint.started += instance.OnSprint;
                @sprint.performed += instance.OnSprint;
                @sprint.canceled += instance.OnSprint;
            }
        }
    }
    public NormalActions @normal => new NormalActions(this);
    private int m_keebSchemeIndex = -1;
    public InputControlScheme keebScheme
    {
        get
        {
            if (m_keebSchemeIndex == -1) m_keebSchemeIndex = asset.FindControlSchemeIndex("keeb");
            return asset.controlSchemes[m_keebSchemeIndex];
        }
    }
    private int m_controllerSchemeIndex = -1;
    public InputControlScheme controllerScheme
    {
        get
        {
            if (m_controllerSchemeIndex == -1) m_controllerSchemeIndex = asset.FindControlSchemeIndex("controller");
            return asset.controlSchemes[m_controllerSchemeIndex];
        }
    }
    public interface INormalActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnItem_use(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}
