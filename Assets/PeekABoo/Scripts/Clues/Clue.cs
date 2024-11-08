using System;
using CardboardCore.DI;

namespace PeekABoo.Clues
{
    public class Clue : CardboardCoreBehaviour
    {
        [Inject] private CluesManager cluesManager;

        public ClueConfig Config { get; private set; }

        public event Action<Clue> CollectedEvent;

        protected override void OnInjected()
        {
            cluesManager.RegisterClue(this);
        }

        protected override void OnReleased()
        {
            cluesManager.UnregisterClue(this);
        }

        public void Init(ClueConfig clueConfig)
        {
            Config = clueConfig;
        }

        public void Collect()
        {
            CollectedEvent?.Invoke(this);
        }
    }
}
