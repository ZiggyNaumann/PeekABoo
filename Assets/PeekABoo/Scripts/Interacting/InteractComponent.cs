using CardboardCore.DI;

namespace PeekABoo.Interacting
{
    public enum InteractionType
    {
        OneOff,
        Toggle
    }

    public abstract class InteractComponent : CardboardCoreBehaviour
    {
        private Interactable interactable;
        private bool isInteracting;

        protected abstract InteractionType InteractionType { get; }

        protected abstract void OnInteractBegin();
        protected abstract void OnInteractEnd();

        protected override void OnInjected()
        {
            interactable = GetComponent<Interactable>();
        }

        protected override void OnReleased()
        {

        }

        public void Interact()
        {
            switch (InteractionType)
            {
                case InteractionType.OneOff:

                    isInteracting = true;
                    OnInteractBegin();

                    isInteracting = false;
                    OnInteractEnd();

                    interactable.DisableInteraction();

                    break;

                case InteractionType.Toggle:

                    isInteracting = !isInteracting;

                    if (isInteracting)
                    {
                        OnInteractBegin();
                    }
                    else
                    {
                        OnInteractEnd();
                    }

                    break;
            }
        }
    }
}
