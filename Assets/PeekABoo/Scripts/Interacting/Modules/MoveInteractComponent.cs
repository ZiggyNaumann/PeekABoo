using System;
using DG.Tweening;
using UnityEngine;

namespace PeekABoo.Interacting.Modules
{
    [Serializable]
    public class MoveConfig
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 targetPosition;
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private Ease moveEase = Ease.OutBack;

        public Transform Target => target;
        public Vector3 TargetPosition => targetPosition;
        public float MoveSpeed => moveSpeed;
        public Ease MoveEase => moveEase;
    }

    public class MoveInteractComponent : InteractComponent
    {
        [SerializeField] private MoveConfig[] moveData;

        protected override InteractionType InteractionType => InteractionType.OneOff;

        protected override void OnInteractBegin()
        {
            foreach (MoveConfig config in moveData)
            {
                config.Target.DOLocalMove(config.TargetPosition, config.MoveSpeed)
                    .SetEase(config.MoveEase);
            }
        }

        protected override void OnInteractEnd()
        {

        }
    }
}
