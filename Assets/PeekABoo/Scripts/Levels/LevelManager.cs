using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Levels
{
    [Injectable]
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelDatabase levelDatabase;

        public Level CurrentLevel { get; private set; }

        public void SpawnLevel(int index)
        {
            if (CurrentLevel != null)
            {
                Destroy(CurrentLevel.gameObject);
            }

            CurrentLevel = Instantiate(levelDatabase.GetLevel(index));
            CurrentLevel.Populate();
        }
    }
}
