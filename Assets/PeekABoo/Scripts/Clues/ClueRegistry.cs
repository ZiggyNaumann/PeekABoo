using System.Collections.Generic;
using CardboardCore.DI;

namespace PeekABoo.Clues
{
    [Injectable]
    public class ClueRegistry
    {
        // TODO: Remove "int" for an in-world painting/door?
        private readonly Dictionary<Clue, int> clues = new Dictionary<Clue, int>();

        private readonly List<ClueSpot> clueSpots = new List<ClueSpot>();

        public IReadOnlyDictionary<Clue, int> Clues => clues;
        public IReadOnlyCollection<ClueSpot> ClueSpots => clueSpots;

        public void RegisterClue(Clue clue)
        {
            clues.TryAdd(clue, 0);
        }

        public void UnregisterClue(Clue clue)
        {
            if (!clues.ContainsKey(clue))
            {
                return;
            }

            clues.Remove(clue);
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
