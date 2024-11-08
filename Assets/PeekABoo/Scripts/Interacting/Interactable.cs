using System;
using CardboardCore.DI;
using CardboardCore.Utilities;
using UnityEngine;

namespace PeekABoo.Interacting
{
    public class Interactable : CardboardCoreBehaviour
    {
        [Inject] private InteractableRegistry interactableRegistry;

        [SerializeField] private GameObject interactableCollidersContainer;
        [SerializeField] private Transform interactPromptPoint;
        [SerializeField] private bool dependsOnParentInteractable;

        private InteractComponent interactComponent;
        private Interactable parentInteractable;

        public Transform InteractPromptPoint => interactPromptPoint;

        public event Action EnableInteractionEvent;
        public event Action DisableInteractionEvent;

        public event Action InteractEvent;

        protected override void OnInjected()
        {
            interactableRegistry.RegisterInteractable(this);

            interactComponent = GetComponent<InteractComponent>();

            if (dependsOnParentInteractable && transform.parent != null)
            {
                parentInteractable = transform.parent.GetComponentInParent<Interactable>();

                if (parentInteractable == null)
                {
                    Log.Warn($"Interactable {name} depends on parent interactable, but no parent interactable found.");
                }
                else
                {
                    parentInteractable.InteractEvent += OnParentInteract;
                    DisableInteraction();
                }
            }
        }

        private void OnParentInteract()
        {
            parentInteractable.InteractEvent -= OnParentInteract;
            EnableInteraction();
        }

        protected override void OnReleased()
        {
            interactableRegistry.UnregisterInteractable(this);
        }

        public void Interact()
        {
            interactComponent.Interact();
            InteractEvent?.Invoke();
        }

        public void ShowHighlight()
        {
            // Show outline
        }

        public void HideHighlight()
        {
            // Hide outline
        }

        public void EnableInteraction()
        {
            interactableCollidersContainer.SetActive(true);
            EnableInteractionEvent?.Invoke();
        }

        public void DisableInteraction()
        {
            interactableCollidersContainer.SetActive(false);
            DisableInteractionEvent?.Invoke();
        }
    }
}
