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
        private bool isInteracting;

        protected abstract InteractionType InteractionType { get; }

        protected abstract void OnInteractBegin();
        protected abstract void OnInteractEnd();

        protected Interactable Interactable { get; private set; }

        protected override void OnInjected()
        {
            Interactable = GetComponent<Interactable>();
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

                    Interactable.DisableInteraction();

                    isInteracting = false;
                    OnInteractEnd();

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
