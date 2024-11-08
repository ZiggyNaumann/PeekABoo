using CardboardCore.DI;
using CardboardCore.UI;
using CardboardCore.Utilities;
using PeekABoo.Interacting;
using PeekABoo.UI.Screens;
using UnityEngine;

namespace PeekABoo.Characters.Players
{
    public class PlayerCharacterInteracting : PlayerCharacterComponent
    {
        [Inject] private UIManager uiManager;

        [SerializeField] private float spherecastRadius = 0.1f;
        [SerializeField] private float spherecastDistance = 5f;

        private PlayerCharacterInput playerCharacterInput;
        private Interactable targetedInteractable;

        private GameplayScreen gameplayScreen;

        protected override void OnInjected()
        {
            base.OnInjected();

            playerCharacterInput = Owner.GetCharacterComponent<PlayerCharacterInput>();
            playerCharacterInput.InteractEvent += OnInteractEvent;

            gameplayScreen = uiManager.GetScreen<GameplayScreen>();
        }

        protected override void OnReleased()
        {
            playerCharacterInput.InteractEvent -= OnInteractEvent;

            base.OnReleased();
        }

        private void OnInteractEvent()
        {
            if (targetedInteractable != null)
            {
                targetedInteractable.Interact();
            }
        }

        private void Update()
        {
            // Spherecast for interactable objects
            RaycastHit[] hits = Physics.SphereCastAll(Owner.FirstPersonCamera.transform.position, spherecastRadius,
                                                      Owner.FirstPersonCamera.transform.forward, spherecastDistance,
                                                      LayerMask.GetMask("Interactable"));

            Interactable nearestInteractable = null;

            foreach (RaycastHit hit in hits)
            {
                Interactable interactable = hit.collider.GetComponentInParent<Interactable>();

                if (!interactable)
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
                bool isInteractableUpdated = false;

                if (targetedInteractable == null)
                {
                    targetedInteractable = nearestInteractable;
                    isInteractableUpdated = true;
                }
                else if (targetedInteractable != nearestInteractable)
                {
                    targetedInteractable.HideHighlight();
                    targetedInteractable = nearestInteractable;
                    isInteractableUpdated = true;
                }

                if (isInteractableUpdated)
                {
                    targetedInteractable.ShowHighlight();

                    Transform point = targetedInteractable.InteractPromptPoint ?? targetedInteractable.transform;
                    gameplayScreen.ShowInteractPrompt(point);

                    targetedInteractable.DisableInteractionEvent += OnTargetedInteractableDisableInteraction;
                }
            }
            else
            {
                if (targetedInteractable != null)
                {
                    targetedInteractable.DisableInteractionEvent -= OnTargetedInteractableDisableInteraction;

                    targetedInteractable.HideHighlight();
                    targetedInteractable = null;

                    gameplayScreen.HideInteractPrompt();
                }
            }
        }

        private void OnTargetedInteractableDisableInteraction()
        {
            if (targetedInteractable == null)
            {
                Log.Warn("Targeted interactable is null.");
                return;
            }

            targetedInteractable.DisableInteractionEvent -= OnTargetedInteractableDisableInteraction;
            targetedInteractable.HideHighlight();
            targetedInteractable = null;

            gameplayScreen.HideInteractPrompt();
        }
    }
}
