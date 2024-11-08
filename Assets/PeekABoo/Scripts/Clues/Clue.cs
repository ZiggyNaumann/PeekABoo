using CardboardCore.DI;

namespace PeekABoo.Clues
{
    public class Clue : CardboardCoreBehaviour
    {
        [Inject] private ClueRegistry clueRegistry;

        protected override void OnInjected()
        {
            clueRegistry.RegisterClue(this);
        }

        protected override void OnReleased()
        {
            clueRegistry.UnregisterClue(this);
        }
    }
}
