using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Clues
{
    public class ClueSpot : CardboardCoreBehaviour
    {
        [Inject] private CluesManager cluesManager;

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
            cluesManager.RegisterClueSpot(this);
        }

        protected override void OnReleased()
        {
            cluesManager.UnregisterClueSpot(this);
        }
    }
}
