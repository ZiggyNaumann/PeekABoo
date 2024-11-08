using CardboardCore.DI;

namespace PeekABoo.Clues
{
    public class Clue : CardboardCoreBehaviour
    {
        [Inject] private ClueRegistry clueRegistry;

        private ClueConfig config;

        protected override void OnInjected()
        {
            clueRegistry.RegisterClue(this);
        }

        protected override void OnReleased()
        {
            clueRegistry.UnregisterClue(this);
        }

        public void Init(ClueConfig clueConfig)
        {
            config = clueConfig;
        }

        public void Collect()
        {

        }
    }
}
