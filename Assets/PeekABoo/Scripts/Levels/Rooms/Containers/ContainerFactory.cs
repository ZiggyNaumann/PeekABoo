using System.Collections.Generic;

namespace PeekABoo.Levels.Rooms.Containers
{
    public class ContainerFactory
    {
        public Container[] SpawnContainers(int amount, ContainerSlot[] slots, Container[] prefabs)
        {
            amount = amount > slots.Length ? slots.Length : amount;

            List<ContainerSlot> eligibleSlots = new List<ContainerSlot>(slots);
            List<Container> containers = new List<Container>();

            for (int i = 0; i < amount; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, eligibleSlots.Count);

                ContainerSlot slot = eligibleSlots[randomIndex];
                eligibleSlots.RemoveAt(randomIndex);

                Container prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
                Container container = UnityEngine.Object.Instantiate(prefab, slot.transform, false);
                containers.Add(container);
            }

            return containers.ToArray();
        }
    }
}
