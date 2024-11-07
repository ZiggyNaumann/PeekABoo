using System;
using PeekABoo.Interacting;
using UnityEngine;
using UnityEngine.Serialization;

namespace PeekABoo.Characters.Players
{
    public class PlayerCharacterInteracting : PlayerCharacterComponent
    {
        [SerializeField] private float spherecastRadius = 0.1f;
        [SerializeField] private float spherecastDistance = 5f;

        private PlayerCharacterInput playerCharacterInput;
        private Interactable targetedInteractable;

        protected override void OnInjected()
        {
            base.OnInjected();

            playerCharacterInput = Owner.GetCharacterComponent<PlayerCharacterInput>();
        }

        private void Update()
        {
            // Spherecast for interactable objects
            RaycastHit[] hits = Physics.SphereCastAll(Owner.FirstPersonCamera.transform.position, spherecastRadius,
                                                      Owner.FirstPersonCamera.transform.forward, spherecastDistance);

            Interactable nearestInteractable = null;

            foreach (RaycastHit hit in hits)
            {
                if (!hit.collider.TryGetComponent(out Interactable interactable))
                {
                    continue;
                }

                if (nearestInteractable == null)
                {
                    nearestInteractable = interactable;
                }
                else
                {
                    float currentDistance = Vector3.Distance(Owner.FirstPersonCamera.transform.position, interactable.transform.position);
                    float nearestDistance = Vector3.Distance(Owner.FirstPersonCamera.transform.position, nearestInteractable.transform.position);

                    if (currentDistance < nearestDistance)
                    {
                        nearestInteractable = interactable;
                    }
                }
            }

            if (nearestInteractable != null)
            {
                if (targetedInteractable == null)
                {
                    targetedInteractable = nearestInteractable;
                    targetedInteractable.ShowHighlight();
                }
                else if (targetedInteractable != nearestInteractable)
                {
                    targetedInteractable.HideHighlight();
                    targetedInteractable = nearestInteractable;
                    targetedInteractable.ShowHighlight();
                }
            }
            else
            {
                if (targetedInteractable != null)
                {
                    targetedInteractable.HideHighlight();
                    targetedInteractable = null;
                }
            }
        }
    }
}
