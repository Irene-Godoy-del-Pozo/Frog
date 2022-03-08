// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/FrogActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FrogActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FrogActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FrogActions"",
    ""maps"": [
        {
            ""name"": ""Play"",
            ""id"": ""2336f86b-6b65-47ac-8102-20d3c342d2e7"",
            ""actions"": [
                {
                    ""name"": ""Trajectory"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bdc7a1c8-852a-47ec-b85e-abc6cbac9a52"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""bdab4a1a-9780-4c67-8401-0829235a29e3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug"",
                    ""type"": ""Button"",
                    ""id"": ""825561c4-33bc-4f38-bc5c-1d870c43e599"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug 2"",
                    ""type"": ""Button"",
                    ""id"": ""390f5259-35d5-4ec6-8c36-d49ac6571c09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ed409a9-67d8-4ded-bac4-849722161507"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Hold(duration=10)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trajectory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58fd4d9d-ddbf-4d27-92ca-f2f313935073"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2069a331-a5cc-4a30-8356-b58760d20af8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4232692-e2d9-4d21-b601-a2b11b1f4de4"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""f844c9c6-6840-407e-b9d3-edc0d24da97f"",
            ""actions"": [
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a155459e-7034-4c2b-9677-5e20acdbbb39"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""03ef6030-245d-4c2f-aa5e-f8885dd2976c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ae2ca91-dfc1-44b0-8ce6-971bb8ea274a"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""798f048b-c31e-4df2-a0b0-9061bbb1ef22"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82d72a12-2975-4ce2-b723-7494f32547ae"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f6eed35-d70e-4d15-a6e0-808d5e706a6b"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Play
        m_Play = asset.FindActionMap("Play", throwIfNotFound: true);
        m_Play_Trajectory = m_Play.FindAction("Trajectory", throwIfNotFound: true);
        m_Play_TouchPosition = m_Play.FindAction("TouchPosition", throwIfNotFound: true);
        m_Play_Debug = m_Play.FindAction("Debug", throwIfNotFound: true);
        m_Play_Debug2 = m_Play.FindAction("Debug 2", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
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

    // Play
    private readonly InputActionMap m_Play;
    private IPlayActions m_PlayActionsCallbackInterface;
    private readonly InputAction m_Play_Trajectory;
    private readonly InputAction m_Play_TouchPosition;
    private readonly InputAction m_Play_Debug;
    private readonly InputAction m_Play_Debug2;
    public struct PlayActions
    {
        private @FrogActions m_Wrapper;
        public PlayActions(@FrogActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Trajectory => m_Wrapper.m_Play_Trajectory;
        public InputAction @TouchPosition => m_Wrapper.m_Play_TouchPosition;
        public InputAction @Debug => m_Wrapper.m_Play_Debug;
        public InputAction @Debug2 => m_Wrapper.m_Play_Debug2;
        public InputActionMap Get() { return m_Wrapper.m_Play; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayActions set) { return set.Get(); }
        public void SetCallbacks(IPlayActions instance)
        {
            if (m_Wrapper.m_PlayActionsCallbackInterface != null)
            {
                @Trajectory.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnTrajectory;
                @Trajectory.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnTrajectory;
                @Trajectory.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnTrajectory;
                @TouchPosition.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnTouchPosition;
                @Debug.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnDebug;
                @Debug.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnDebug;
                @Debug.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnDebug;
                @Debug2.started -= m_Wrapper.m_PlayActionsCallbackInterface.OnDebug2;
                @Debug2.performed -= m_Wrapper.m_PlayActionsCallbackInterface.OnDebug2;
                @Debug2.canceled -= m_Wrapper.m_PlayActionsCallbackInterface.OnDebug2;
            }
            m_Wrapper.m_PlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Trajectory.started += instance.OnTrajectory;
                @Trajectory.performed += instance.OnTrajectory;
                @Trajectory.canceled += instance.OnTrajectory;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @Debug.started += instance.OnDebug;
                @Debug.performed += instance.OnDebug;
                @Debug.canceled += instance.OnDebug;
                @Debug2.started += instance.OnDebug2;
                @Debug2.performed += instance.OnDebug2;
                @Debug2.canceled += instance.OnDebug2;
            }
        }
    }
    public PlayActions @Play => new PlayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    public struct UIActions
    {
        private @FrogActions m_Wrapper;
        public UIActions(@FrogActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayActions
    {
        void OnTrajectory(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnDebug(InputAction.CallbackContext context);
        void OnDebug2(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
