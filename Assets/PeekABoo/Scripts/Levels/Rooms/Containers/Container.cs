using PeekABoo.Clues;
using UnityEngine;

namespace PeekABoo.Levels.Rooms.Containers
{
    public class Container : MonoBehaviour
    {
        public ClueSpot GetClueSpot()
        {
            return GetComponentInChildren<ClueSpot>();
        }
    }
}
