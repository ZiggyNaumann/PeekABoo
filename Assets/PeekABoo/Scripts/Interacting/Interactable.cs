using CardboardCore.DI;

namespace PeekABoo.Interacting
{
    public class Interactable : CardboardCoreBehaviour
    {
        [Inject] private InteractableRegistry interactableRegistry;

        protected override void OnInjected()
        {
            interactableRegistry.RegisterInteractable(this);
        }

        protected override void OnReleased()
        {
            interactableRegistry.UnregisterInteractable(this);
        }

        public void ShowHighlight()
        {
            // Show outline
        }

        public void HideHighlight()
        {
            // Hide outline
        }
    }
}
