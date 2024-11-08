using System;
using CardboardCore.DI;
using DG.Tweening;
using UnityEngine;

namespace PeekABoo.Levels.Rooms.Doors
{
    [Serializable]
    public class DoorTransitionStep
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Ease ease;

        public Vector3 Offset => offset;
        public Ease Ease => ease;

        public Vector3 GetTargetLocalPosition(Transform transform)
        {
            // Get offset based on transform's forward vector
            Vector3 targetPosition = transform.position + transform.forward * offset.z;
            targetPosition += transform.right * offset.x;
            targetPosition += transform.up * offset.y;

            return targetPosition;
        }
    }

    [Serializable]
    public class DoorTransition
    {
        [SerializeField] private DoorTransitionStep[] steps;

        public DoorTransitionStep[] Steps => steps;
    }

    public class Door : CardboardCoreBehaviour
    {
        [SerializeField] private DoorTransition doorTransition;

        private int doorClueIndex = -1;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.2f);
            Gizmos.DrawRay(transform.position, transform.forward);

            Vector3 position = transform.position + transform.up * 0.25f;
            UnityEditor.Handles.Label(position, "Door");
        }
#endif

        protected override void OnInjected()
        {

        }

        protected override void OnReleased()
        {

        }

        public void SetOpenable(int index)
        {
            doorClueIndex = index;
        }

        public bool TryOpen(int playerClueIndex)
        {
            if (playerClueIndex < doorClueIndex)
            {
                return false;
            }

            Sequence sequence = DOTween.Sequence();

            for (int i = 0; i < doorTransition.Steps.Length; i++)
            {
                DoorTransitionStep step = doorTransition.Steps[i];

                sequence.Append(transform.DOLocalMove(step.GetTargetLocalPosition(transform), 1f)
                    .SetEase(step.Ease));
            }

            return true;
        }
    }
}
