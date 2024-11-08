using PeekABoo.Clues;

namespace PeekABoo.Interacting.Modules
{
    public class CollectInteractComponent : InteractComponent
    {
        protected override InteractionType InteractionType => InteractionType.OneOff;

        protected override void OnInteractBegin()
        {
            Clue clue = Interactable.GetComponent<Clue>();

            if (!clue)
            {
                return;
            }

            clue.Collect();
        }

        protected override void OnInteractEnd()
        {
            Destroy(Interactable.gameObject);
        }
    }
}
