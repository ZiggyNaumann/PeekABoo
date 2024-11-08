using CardboardCore.DI;

namespace PeekABoo.Clues
{
    [Injectable]
    public class ClueProgress
    {
        public int TotalClues { get; private set; }
        public int CollectedClues { get; private set; }

        public void SetTotalClues(int totalClues)
        {
            TotalClues = totalClues;
        }

        public void CollectClue()
        {
            CollectedClues++;
        }
    }
}
