using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Clues
{
    public class ClueSpot : CardboardCoreBehaviour
    {
        [Inject] private ClueRegistry clueRegistry;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(transform.position, 0.1f);
            Gizmos.DrawRay(transform.position, transform.forward * 0.3f);

            UnityEditor.Handles.Label(transform.position, "Clue Spot");
        }
#endif

        protected override void OnInjected()
        {
            clueRegistry.RegisterClueSpot(this);
        }

        protected override void OnReleased()
        {
            clueRegistry.UnregisterClueSpot(this);
        }
    }
}
