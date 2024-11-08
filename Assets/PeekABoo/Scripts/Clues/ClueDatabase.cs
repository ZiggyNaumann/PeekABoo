using UnityEngine;

namespace PeekABoo.Clues
{
    [CreateAssetMenu(fileName = "ClueDatabase", menuName = "PeekABoo/Clues/ClueDatabase")]
    public class ClueDatabase : ScriptableObject
    {
        [SerializeField] private ClueConfig[] clueConfigs;

        public ClueConfig[] ClueConfigs => clueConfigs;
    }
}
