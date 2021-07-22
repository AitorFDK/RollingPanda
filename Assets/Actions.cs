// GENERATED AUTOMATICALLY FROM 'Assets/Actions.inputactions'

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
            ""name"": ""Movimiento"",
            ""id"": ""6a1bfe59-1582-4367-87b6-b911609b44ee"",
            ""actions"": [
                {
                    ""name"": ""Saltar"",
                    ""type"": ""Button"",
                    ""id"": ""18b2d00b-02ad-4bbf-9694-6012c4317fa7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mover"",
                    ""type"": ""Value"",
                    ""id"": ""b3b37a4c-266d-4e38-8b6e-95f9bd09bb15"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": ""InvertVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cambio"",
                    ""type"": ""Button"",
                    ""id"": ""c6a0a1bb-b077-4a79-ab6b-b59823e905a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a938c80f-8664-4e12-bc6d-24d2c74ac1ea"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mando"",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adf046be-c346-42e0-b6a2-11a14a98c73d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""ff9c0e47-df2c-48ea-9565-6745e48d4154"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""48f80fd8-a95a-4210-a58e-43e462f6c6c7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ca18cd23-9252-42c7-b90b-0e96c46255f0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""166d65e2-1cd9-481e-acf0-a9011d473c6e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7b7ba03b-59e2-4a4f-b424-b3f671f99da9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Flechas"",
                    ""id"": ""cfcd69a9-19de-463f-8c82-9ecb0fbddb9b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2fe6698b-f38e-4014-af71-e2fcf37c6569"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""57506495-0e00-4d25-b95f-4c4c9bc9f611"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fb60f81c-e626-4241-b315-70dc94f35f23"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8b5539e4-0969-4665-bf04-bd323f07c2c0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d73c6dd5-1813-4c9e-af40-ab340bfe8d40"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mando"",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efe86a61-f81f-4c9d-9ac9-15d0643fdd1b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mando"",
                    ""action"": ""Cambio"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5732908-67f3-4be2-96a4-598b3ae48e2e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado"",
                    ""action"": ""Cambio"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Teclado"",
            ""bindingGroup"": ""Teclado"",
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
            ""name"": ""Mando"",
            ""bindingGroup"": ""Mando"",
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
        // Movimiento
        m_Movimiento = asset.FindActionMap("Movimiento", throwIfNotFound: true);
        m_Movimiento_Saltar = m_Movimiento.FindAction("Saltar", throwIfNotFound: true);
        m_Movimiento_Mover = m_Movimiento.FindAction("Mover", throwIfNotFound: true);
        m_Movimiento_Cambio = m_Movimiento.FindAction("Cambio", throwIfNotFound: true);
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

    // Movimiento
    private readonly InputActionMap m_Movimiento;
    private IMovimientoActions m_MovimientoActionsCallbackInterface;
    private readonly InputAction m_Movimiento_Saltar;
    private readonly InputAction m_Movimiento_Mover;
    private readonly InputAction m_Movimiento_Cambio;
    public struct MovimientoActions
    {
        private @Actions m_Wrapper;
        public MovimientoActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Saltar => m_Wrapper.m_Movimiento_Saltar;
        public InputAction @Mover => m_Wrapper.m_Movimiento_Mover;
        public InputAction @Cambio => m_Wrapper.m_Movimiento_Cambio;
        public InputActionMap Get() { return m_Wrapper.m_Movimiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimientoActions set) { return set.Get(); }
        public void SetCallbacks(IMovimientoActions instance)
        {
            if (m_Wrapper.m_MovimientoActionsCallbackInterface != null)
            {
                @Saltar.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnSaltar;
                @Saltar.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnSaltar;
                @Saltar.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnSaltar;
                @Mover.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnMover;
                @Mover.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnMover;
                @Mover.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnMover;
                @Cambio.started -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnCambio;
                @Cambio.performed -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnCambio;
                @Cambio.canceled -= m_Wrapper.m_MovimientoActionsCallbackInterface.OnCambio;
            }
            m_Wrapper.m_MovimientoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Saltar.started += instance.OnSaltar;
                @Saltar.performed += instance.OnSaltar;
                @Saltar.canceled += instance.OnSaltar;
                @Mover.started += instance.OnMover;
                @Mover.performed += instance.OnMover;
                @Mover.canceled += instance.OnMover;
                @Cambio.started += instance.OnCambio;
                @Cambio.performed += instance.OnCambio;
                @Cambio.canceled += instance.OnCambio;
            }
        }
    }
    public MovimientoActions @Movimiento => new MovimientoActions(this);
    private int m_TecladoSchemeIndex = -1;
    public InputControlScheme TecladoScheme
    {
        get
        {
            if (m_TecladoSchemeIndex == -1) m_TecladoSchemeIndex = asset.FindControlSchemeIndex("Teclado");
            return asset.controlSchemes[m_TecladoSchemeIndex];
        }
    }
    private int m_MandoSchemeIndex = -1;
    public InputControlScheme MandoScheme
    {
        get
        {
            if (m_MandoSchemeIndex == -1) m_MandoSchemeIndex = asset.FindControlSchemeIndex("Mando");
            return asset.controlSchemes[m_MandoSchemeIndex];
        }
    }
    public interface IMovimientoActions
    {
        void OnSaltar(InputAction.CallbackContext context);
        void OnMover(InputAction.CallbackContext context);
        void OnCambio(InputAction.CallbackContext context);
    }
}
