using System;
using CardboardCore.DI;
using DG.Tweening;
using PeekABoo.Clues;
using PeekABoo.Levels.Rooms.Paintings;
using UnityEngine;
using UnityEngine.Serialization;

namespace PeekABoo.Levels.Rooms.Doors
{
    [Serializable]
    public class DoorTransitionStep
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Ease ease;
        [SerializeField] private float duration = 1f;

        public Vector3 Offset => offset;
        public Ease Ease => ease;
        public float Duration => duration;
    }

    [Serializable]
    public class DoorTransition
    {
        [SerializeField] private Transform animationRoot;
        [SerializeField] private Collider[] collidersToDisable;
        [SerializeField] private DoorTransitionStep[] steps;

        public Transform AnimationRoot => animationRoot;
        public Collider[] CollidersToDisable => collidersToDisable;
        public DoorTransitionStep[] Steps => steps;
    }

    public class Door : CardboardCoreBehaviour
    {
        [Inject] private CluesManager cluesManager;

        [SerializeField] private Painting painting;
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
            painting.PaintingInteractEvent += OnPaintingInteract;
        }

        protected override void OnReleased()
        {
            painting.PaintingInteractEvent -= OnPaintingInteract;
        }

        public void SetOpenable(int index, ClueConfig clueConfig)
        {
            doorClueIndex = index;

            painting.SetTexture(clueConfig.Sprite);
        }

        private void OnPaintingInteract()
        {
            if (doorClueIndex == -1 || !TryOpen(cluesManager.ClueProgress.CollectedAmount - 1))
            {
                // TODO: Trigger alarm and after a timeout reset the painting's interactability
            }
        }

        public bool TryOpen(int playerClueIndex)
        {
            if (playerClueIndex < doorClueIndex)
            {
                return false;
            }

            foreach (Collider collider in doorTransition.CollidersToDisable)
            {
                collider.enabled = false;
            }

            Sequence sequence = DOTween.Sequence();

            Vector3 startPosition = doorTransition.AnimationRoot.localPosition;
            Vector3 totalOffset = Vector3.zero;

            for (int i = 0; i < doorTransition.Steps.Length; i++)
            {
                DoorTransitionStep step = doorTransition.Steps[i];

                totalOffset += step.Offset;

                sequence.Append(doorTransition.AnimationRoot.DOLocalMove(startPosition + totalOffset, step.Duration)
                    .SetEase(step.Ease));
            }

            return true;
        }
    }
}
