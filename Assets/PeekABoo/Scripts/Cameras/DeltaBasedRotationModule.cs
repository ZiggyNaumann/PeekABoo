using CardboardCore.Cameras.Modules;
using UnityEngine;

namespace PeekABoo.Cameras
{
    public class DeltaBasedRotationModule : CameraModule
    {
        [SerializeField] private float minRotationX = -80f;
        [SerializeField] private float maxRotationX = 80f;

        private Vector2 currentRotation;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

            // Rotate the camera based on rotation value
            currentRotation.x = Mathf.Clamp(currentRotation.x, -maxRotationX, -minRotationX);

            Quaternion currentRotationQuat = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
            Transform.localRotation = currentRotationQuat;
        }

        public void AddDelta(Vector2 deltaInput)
        {
            currentRotation.x -= deltaInput.y;
            currentRotation.y += deltaInput.x;
        }
    }
}
