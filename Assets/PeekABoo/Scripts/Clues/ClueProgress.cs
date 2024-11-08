using System.Collections.Generic;

namespace PeekABoo.Clues
{
    public class ClueProgress
    {
        private readonly List<ClueConfig> collectedClues = new List<ClueConfig>();

        public IReadOnlyList<ClueConfig> CollectedClues => collectedClues;
        public int CollectedAmount => collectedClues.Count;

        public void Reset()
        {
            collectedClues.Clear();
        }

        public void CollectClue(Clue clue)
        {
            if (collectedClues.Contains(clue.Config))
            {
                return;
            }

            collectedClues.Add(clue.Config);
        }
    }
}
