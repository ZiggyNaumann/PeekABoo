using System.Collections.Generic;
using CardboardCore.DI;

namespace PeekABoo.Interacting
{
    [Injectable]
    public class InteractableRegistry
    {
        private readonly List<Interactable> interactables = new List<Interactable>();

        public void RegisterInteractable(Interactable interactable)
        {
            if (interactables.Contains(interactable))
            {
                return;
            }

            interactables.Add(interactable);
        }

        public void UnregisterInteractable(Interactable interactable)
        {
            if (!interactables.Contains(interactable))
            {
                return;
            }

            interactables.Remove(interactable);
        }
    }
}
