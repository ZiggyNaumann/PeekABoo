using System;
using System.Collections.Generic;
using CardboardCore.DI;

namespace PeekABoo.Clues
{
    [Injectable]
    public class CluesManager
    {
        private readonly List<Clue> clues = new List<Clue>();
        private readonly List<ClueSpot> clueSpots = new List<ClueSpot>();

        public ClueProgress ClueProgress { get; } = new ClueProgress();

        public IReadOnlyCollection<Clue> Clues => clues;
        public IReadOnlyCollection<ClueSpot> ClueSpots => clueSpots;

        public event Action<Clue> ClueCollectedEvent;

        private void OnClueCollected(Clue clue)
        {
            ClueProgress.CollectClue(clue);
            ClueCollectedEvent?.Invoke(clue);
        }

        public void RegisterClue(Clue clue)
        {
            if (clues.Contains(clue))
            {
                return;
            }

            clues.Add(clue);

            clue.CollectedEvent += OnClueCollected;
        }

        public void UnregisterClue(Clue clue)
        {
            if (!clues.Contains(clue))
            {
                return;
            }

            clues.Remove(clue);

            clue.CollectedEvent -= OnClueCollected;
        }

        public ClueConfig GetClueConfig(int index)
        {
            if (index < 0 || index >= clues.Count)
            {
                return null;
            }

            return clues[index].Config;
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
