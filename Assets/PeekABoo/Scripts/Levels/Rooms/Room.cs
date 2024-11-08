using CardboardCore.DI;
using PeekABoo.Clues;
using PeekABoo.Levels.Rooms.Containers;
using PeekABoo.Levels.Rooms.Doors;
using UnityEngine;

namespace PeekABoo.Levels.Rooms
{
    public class Room : CardboardCoreBehaviour
    {
        [SerializeField] private int preferredContainerCount = 3;
        [SerializeField] private Container[] containerPrefabs;

        private ContainerSlot[] containerSlots;
        private Door[] doors;
        private Container[] containers;

        private ContainerFactory containerFactory;

        protected override void OnInjected()
        {

        }

        protected override void OnReleased()
        {

        }

        private void PopulateContainers()
        {
            containerSlots = GetComponentsInChildren<ContainerSlot>();
            doors = GetComponentsInChildren<Door>();

            containerFactory = new ContainerFactory();
            containers = containerFactory.SpawnContainers(preferredContainerCount, containerSlots, containerPrefabs);
        }

        public void Populate()
        {
            PopulateContainers();
        }

        public ClueSpot GetRandomClueSpot()
        {
            int randomContainerIndex = Random.Range(0, containers.Length);
            Container container = containers[randomContainerIndex];
            return container.GetClueSpot();
        }
    }
}
