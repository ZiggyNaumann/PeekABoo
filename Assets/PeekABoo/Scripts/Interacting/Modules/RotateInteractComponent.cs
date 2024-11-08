using System;
using DG.Tweening;
using UnityEngine;

namespace PeekABoo.Interacting.Modules
{
    [Serializable]
    public class RotateConfig
    {
        [SerializeField] private Transform target;
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private Vector3 targetEuler;
        [SerializeField] private Ease rotationEase = Ease.OutBack;

        public Transform Target => target;
        public float RotationSpeed => rotationSpeed;
        public Vector3 TargetEuler => targetEuler;
        public Ease RotationEase => rotationEase;
    }

    public class RotateInteractComponent : InteractComponent
    {
        [SerializeField] private RotateConfig[] rotateData;

        protected override InteractionType InteractionType => InteractionType.OneOff;

        protected override void OnInteractBegin()
        {
            foreach (RotateConfig config in rotateData)
            {
                config.Target.DOLocalRotate(config.TargetEuler, config.RotationSpeed, RotateMode.LocalAxisAdd)
                    .SetEase(config.RotationEase);
            }
        }

        protected override void OnInteractEnd()
        {

        }
    }
}
