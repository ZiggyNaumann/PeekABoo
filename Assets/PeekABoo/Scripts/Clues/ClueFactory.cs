using System.Collections.Generic;
using System.Linq;
using CardboardCore.DI;
using CardboardCore.Utilities;
using UnityEngine;

namespace PeekABoo.Clues
{
    public class ClueSpawnConfig
    {
        public ClueConfig ClueConfig { get; }
        public ClueSpot ClueSpot { get; }

        public ClueSpawnConfig(ClueConfig clueConfig, ClueSpot clueSpot)
        {
            ClueConfig = clueConfig;
            ClueSpot = clueSpot;
        }
    }

    [Injectable]
    public class ClueFactory : MonoBehaviour
    {
        [SerializeField] private ClueDatabase clueDatabase;

        private List<ClueConfig> clueConfigs;
        private List<ClueSpawnConfig> activeClues;

        public void InitLevelClues(IReadOnlyCollection<ClueSpot> clueSpots)
        {
            int amount = clueSpots.Count;

            if (amount > clueDatabase.ClueConfigs.Length)
            {
                amount = clueDatabase.ClueConfigs.Length;

                Log.Warn("Amount of clues requested is greater than the amount of clues in the database. " +
                         "Amount of clues has been set to the amount of clues in the database.");
            }

            clueConfigs = new List<ClueConfig>(clueDatabase.ClueConfigs);
            activeClues = new List<ClueSpawnConfig>();

            for (int i = 0; i < amount; i++)
            {
                int randomIndex = Random.Range(0, clueConfigs.Count);
                activeClues.Add(new ClueSpawnConfig(clueConfigs[randomIndex], clueSpots.ElementAt(i)));

                clueConfigs.RemoveAt(randomIndex);
            }
        }

        public void SpawnAllClues()
        {
            foreach (ClueSpawnConfig clueSpawnConfig in activeClues)
            {
                Clue clue = Instantiate(clueSpawnConfig.ClueConfig.CluePrefab, clueSpawnConfig.ClueSpot.transform);
                clue.Init(clueSpawnConfig.ClueConfig);
            }
        }
    }
}
