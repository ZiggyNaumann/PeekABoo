using UnityEngine;

namespace PeekABoo.Levels
{
    [CreateAssetMenu(fileName = "LevelDatabase", menuName = "PeekABoo/Levels/LevelDatabase")]
    public class LevelDatabase : ScriptableObject
    {
        [SerializeField] private Level[] levels;

        public Level GetLevel(int index)
        {
            return levels[index];
        }

        public int GetLevelCount()
        {
            return levels.Length;
        }
    }
}
