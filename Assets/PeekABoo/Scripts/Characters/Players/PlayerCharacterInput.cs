using System;
using CardboardCore.DI;
using PeekABook.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PeekABoo.Characters.Players
{
    public class PlayerCharacterInput : PlayerCharacterComponent
    {
        [Inject] private InputManager inputManager;

        [SerializeField] private float lookSensitivity = 1.0f;

        private bool initialLookInputGiven;

        public Vector2 LookDelta { get; private set; }
        public Vector3 MoveDirection { get; private set; }

        public event Action CrouchEvent;
        public event Action<bool> SprintEvent;

        protected override void OnInjected()
        {
            base.OnInjected();

            inputManager.Player.Look.performed += OnLookPerformed;
            inputManager.Player.Look.canceled += OnLookPerformed;

            inputManager.Player.Move.performed += OnMovePerformed;
            inputManager.Player.Move.canceled += OnMovePerformed;

            inputManager.Player.Crouch.performed += OnCrouchPerformed;

            inputManager.Player.Sprint.performed += OnSprintPerformed;
            inputManager.Player.Sprint.canceled += OnSprintPerformed;

        }

        protected override void OnReleased()
        {
            inputManager.Player.Look.performed -= OnLookPerformed;
            inputManager.Player.Look.canceled -= OnLookPerformed;

            inputManager.Player.Move.performed -= OnMovePerformed;
            inputManager.Player.Move.canceled -= OnMovePerformed;

            inputManager.Player.Crouch.performed -= OnCrouchPerformed;

            inputManager.Player.Sprint.performed -= OnSprintPerformed;
            inputManager.Player.Sprint.canceled -= OnSprintPerformed;

            base.OnReleased();
        }

        private void OnLookPerformed(InputAction.CallbackContext obj)
        {
            // TODO: Get rid of this dumb check, it's a workaround for the fact that the first input is always super high
            if (!initialLookInputGiven)
            {
                initialLookInputGiven = true;
                return;
            }

            Vector2 pixelBasedDelta = obj.ReadValue<Vector2>();
            Vector2 normalizedDelta = pixelBasedDelta * lookSensitivity * Time.deltaTime;

            LookDelta = normalizedDelta;
        }

        private void OnMovePerformed(InputAction.CallbackContext obj)
        {
            Vector2 localMoveInput = obj.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(localMoveInput.x, 0, localMoveInput.y);

            MoveDirection = moveDirection;
        }

        private void OnCrouchPerformed(InputAction.CallbackContext obj)
        {
            CrouchEvent?.Invoke();
        }

        private void OnSprintPerformed(InputAction.CallbackContext obj)
        {
            SprintEvent?.Invoke(obj.performed);
        }
    }
}
