using System;
using System.Collections.Generic;
using CardboardCore.DI;

namespace PeekABoo.Clues
{
    [Injectable]
    public class CluesManager
    {
        // TODO: Remove "int" for an in-world painting/door?
        private readonly Dictionary<Clue, int> clues = new Dictionary<Clue, int>();
        private readonly List<ClueSpot> clueSpots = new List<ClueSpot>();

        public ClueProgress ClueProgress { get; } = new ClueProgress();

        public IReadOnlyDictionary<Clue, int> Clues => clues;
        public IReadOnlyCollection<ClueSpot> ClueSpots => clueSpots;

        public event Action<Clue> ClueCollectedEvent;

        private void OnClueCollected(Clue clue)
        {
            ClueProgress.CollectClue(clue);
            ClueCollectedEvent?.Invoke(clue);
        }

        public void RegisterClue(Clue clue)
        {
            if (!clues.TryAdd(clue, 0))
            {
                return;
            }

            clue.CollectedEvent += OnClueCollected;
        }

        public void UnregisterClue(Clue clue)
        {
            if (!clues.ContainsKey(clue))
            {
                return;
            }

            clues.Remove(clue);

            clue.CollectedEvent -= OnClueCollected;
        }

        public void RegisterClueSpot(ClueSpot clueSpot)
        {
            if (clueSpots.Contains(clueSpot))
            {
                return;
            }

            clueSpots.Add(clueSpot);
        }

        public void UnregisterClueSpot(ClueSpot clueSpot)
        {
            if (!clueSpots.Contains(clueSpot))
            {
                return;
            }

            clueSpots.Remove(clueSpot);
        }
    }
}
