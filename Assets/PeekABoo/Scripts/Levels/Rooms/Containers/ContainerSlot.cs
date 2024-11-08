using CardboardCore.DI;
using UnityEditor;
using UnityEngine;

namespace PeekABoo.Levels.Rooms.Containers
{
    public class ContainerSlot : CardboardCoreBehaviour
    {
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.2f);
            Gizmos.DrawRay(transform.position, transform.forward);

            Vector3 position = transform.position + transform.up * 0.25f;
            Handles.Label(position, "Container Slot");
        }
#endif

        protected override void OnInjected()
        {

        }

        protected override void OnReleased()
        {

        }
    }
}
