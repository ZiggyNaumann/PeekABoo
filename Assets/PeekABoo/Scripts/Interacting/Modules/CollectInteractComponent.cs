namespace PeekABoo.Interacting.Modules
{
    public class CollectInteractComponent : InteractComponent
    {
        protected override InteractionType InteractionType => InteractionType.OneOff;

        protected override void OnInteractBegin()
        {
            // TODO: Collect item into inventory
        }

        protected override void OnInteractEnd()
        {
            Destroy(Interactable.gameObject);
        }
    }
}
