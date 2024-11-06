using System.Collections.Generic;
using CardboardCore.Cameras.VirtualCameras;
using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Characters.Players
{
    public class PlayerCharacterMovement : PlayerCharacterComponent
    {
        [Header("References")]
        [SerializeField] private new Rigidbody rigidbody;

        [Header("Movement Settings")]
        [SerializeField] private float accelerationStrength = 300f;
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float counterFriction = 0.1f;

        [Header("Jump Settings")]
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float isGroundedCheckOffset = 1f;
        [SerializeField] private float isGroundedCheckDistance = 1.1f;
        [SerializeField] private float jumpDirectionalForce = 20f;
        [SerializeField] private float maxAirSpeed = 5f;
        [SerializeField] private float airAccelerationStrength = 150f;

        [Inject] private VirtualCameraManager virtualCameraManager;

        private PlayerCharacterInput playerCharacterInput;

        private Vector3 currentVelocity;
        private Vector3 previousVelocity;
        private Vector3 counterFrictionVelocity;

        public bool IsGrounded { get; private set; }

        protected override void OnInjected()
        {
            base.OnInjected();

            playerCharacterInput = Owner.GetCharacterComponent<PlayerCharacterInput>();
        }

        private void FixedUpdate()
        {
            Vector3 isGroundedCheckPosition = transform.position;
            isGroundedCheckPosition.y += isGroundedCheckOffset;

            // Check if grounded
            List<RaycastHit> hits = new List<RaycastHit>(Physics.RaycastAll(isGroundedCheckPosition, Vector3.down, isGroundedCheckDistance));

            for (int i = hits.Count - 1; i >= 0; i--)
            {
                if (hits[i].transform == transform || hits[i].collider.isTrigger || hits[i].transform.IsChildOf(transform))
                {
                    hits.RemoveAt(i);
                }
            }

            IsGrounded = hits.Count > 0;

            Debug.DrawRay(isGroundedCheckPosition, Vector3.down * isGroundedCheckDistance, IsGrounded ? Color.green : Color.red);

            Vector3 moveDirection = playerCharacterInput.MoveDirection;

            virtualCameraManager.CameraController.ProjectOnPlane(ref moveDirection);

            if (playerCharacterInput.MoveDirection == Vector3.zero)
            {
                return;
            }

            float acceleration = IsGrounded ? accelerationStrength : airAccelerationStrength;

            moveDirection *= acceleration * Time.fixedDeltaTime;
            rigidbody.AddForce(moveDirection, ForceMode.Force);

            previousVelocity = rigidbody.linearVelocity;

            Vector3 comparableVelocity = previousVelocity;
            comparableVelocity.y = 0;

            currentVelocity = Vector3.zero;

            float maxMovementSpeed = IsGrounded ? maxSpeed : maxAirSpeed;

            if (comparableVelocity.magnitude > maxMovementSpeed)
            {
                currentVelocity = previousVelocity.normalized * maxMovementSpeed;
                currentVelocity.y = previousVelocity.y;

                rigidbody.linearVelocity = currentVelocity;
            }
        }

        private void LateUpdate()
        {
            if (!IsGrounded)
            {
                return;
            }

            if (playerCharacterInput.MoveDirection != Vector3.zero)
            {
                return;
            }

            Vector3 targetVelocity = Vector3.zero;
            targetVelocity.y = rigidbody.linearVelocity.y;

            // Can happen when e.g. dying
            if (rigidbody.isKinematic)
            {
                return;
            }

            rigidbody.linearVelocity = Vector3.SmoothDamp(rigidbody.linearVelocity, targetVelocity, ref counterFrictionVelocity, counterFriction);
        }
    }
}
