using System;
using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Interacting
{
    [Serializable]
    public class InteractableChainConfig
    {
        [SerializeField] private Interactable dependentInteractable;

        public Interactable DependentInteractable => dependentInteractable;
    }

    public class Interactable : CardboardCoreBehaviour
    {
        [Inject] private InteractableRegistry interactableRegistry;

        [SerializeField] private GameObject interactableCollidersContainer;
        [SerializeField] private Transform interactPromptPoint;

        [SerializeField] private InteractableChainConfig[] interactableChainConfigs;

        private InteractComponent interactComponent;

        public Transform InteractPromptPoint => interactPromptPoint;

        public event Action EnableInteractionEvent;
        public event Action DisableInteractionEvent;

        protected override void OnInjected()
        {
            interactableRegistry.RegisterInteractable(this);

            interactComponent = GetComponent<InteractComponent>();

            foreach (InteractableChainConfig chainConfig in interactableChainConfigs)
            {
                chainConfig.DependentInteractable.DisableInteraction();
            }
        }

        protected override void OnReleased()
        {
            interactableRegistry.UnregisterInteractable(this);
        }

        public void Interact()
        {
            interactComponent.Interact();

            foreach (InteractableChainConfig chainConfig in interactableChainConfigs)
            {
                chainConfig.DependentInteractable.EnableInteraction();
            }
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
