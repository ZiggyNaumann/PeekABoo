using System;
using System.Collections.Generic;
using CardboardCore.DI;
using CardboardCore.Utilities;
using PeekABoo.Clues;
using PeekABoo.Levels.Rooms;
using PeekABoo.Levels.Rooms.Doors;
using UnityEngine;

namespace PeekABoo.Levels
{
    [Serializable]
    public class LevelProgression
    {
        [Tooltip("Select doors in the order they will be opened in the level")]
        [SerializeField] private Door[] openableDoors;

        public Door[] OpenableDoors => openableDoors;
    }

    public class Level : CardboardCoreBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private LevelProgression levelProgression;

        private Room[] rooms;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (spawnPoint == null)
            {
                Log.Exception($"Spawn point is not set in Level: {name}");
                return;
            }

            Color color = Color.blue;
            color.a = 0.5f;
            Gizmos.color = color;
            Gizmos.DrawSphere(spawnPoint.position, 0.5f);

            Gizmos.color = Color.green;
            Gizmos.DrawRay(spawnPoint.position, spawnPoint.forward);

            Vector3 position = spawnPoint.position + spawnPoint.up * 0.25f;
            UnityEditor.Handles.Label(position, "Spawn Point");
        }
#endif

        protected override void OnInjected()
        {
            rooms = GetComponentsInChildren<Room>();
        }

        protected override void OnReleased()
        {
        }

        public void Populate()
        {
            foreach (Room room in rooms)
            {
                room.Populate();
            }

            for (int i = 0; i < levelProgression.OpenableDoors.Length; i++)
            {
                Door door = levelProgression.OpenableDoors[i];
                door.SetOpenable(i);
            }
        }

        public void TeleportToSpawnPoint(Transform transform)
        {
            Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
            rigidbody.MovePosition(spawnPoint.position);
            rigidbody.MoveRotation(spawnPoint.rotation);
        }

        public ClueSpot[] GetOneClueSpotPerRoom()
        {
            List<ClueSpot> clueSpots = new List<ClueSpot>();

            foreach (Room room in rooms)
            {
                ClueSpot clueSpot = room.GetRandomClueSpot();
                clueSpots.Add(clueSpot);
            }

            return clueSpots.ToArray();
        }
    }
}
