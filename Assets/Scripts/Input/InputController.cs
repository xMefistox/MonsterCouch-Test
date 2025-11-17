using MonsterCouchTest.Zenject.Signals;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace MonsterCouchTest.Input
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;

        private Vector2 movementInput;

        protected SignalBus signalBus;
        protected InputSystem_Actions inputActions;

        [Inject]
        private void Construct(SignalBus signalBus, InputSystem_Actions inputActions)
        {
            this.signalBus = signalBus;
            this.inputActions = inputActions;
        }

        private void Awake()
        {
            inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            inputActions.Player.GoBackToMainMenu.performed += ctx => signalBus.Fire(new GoToMainMenuSignal(this.gameObject));
        }

        private void OnEnable()
        {
            inputActions.Player.Enable();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDisable()
        {
            inputActions.Player.Disable();
        }

        private void FixedUpdate()
        {
            movementController.Move(movementInput);
        }
    }
}
