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
    public struct PlayActions
    {
        private @FrogActions m_Wrapper;
        public PlayActions(@FrogActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Trajectory => m_Wrapper.m_Play_Trajectory;
        public InputAction @TouchPosition => m_Wrapper.m_Play_TouchPosition;
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
            }
        }
    }
    public PlayActions @Play => new PlayActions(this);
    public interface IPlayActions
    {
        void OnTrajectory(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
