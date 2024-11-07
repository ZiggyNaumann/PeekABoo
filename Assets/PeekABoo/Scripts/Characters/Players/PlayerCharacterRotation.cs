using CardboardCore.Utilities;
using PeekABoo.Cameras;
using UnityEngine;

namespace PeekABoo.Characters.Players
{
    public class PlayerCharacterRotation : PlayerCharacterComponent
    {
        [SerializeField] private Transform viewTransform;

        private PlayerCharacterInput playerCharacterInput;
        private DeltaBasedRotationModule deltaBasedRotationModule;

        protected override void OnInjected()
        {
            base.OnInjected();

            playerCharacterInput = Owner.GetCharacterComponent<PlayerCharacterInput>();

            if (!Owner.FirstPersonCamera.TryGetCameraModule(out deltaBasedRotationModule))
            {
                Log.Exception($"Could not find LookAroundModule in virtual camera with name 'FirstPerson'");
            }
        }

        private void Update()
        {
            deltaBasedRotationModule.AddDelta(playerCharacterInput.LookDelta);

            Vector3 targetEuler = Owner.FirstPersonCamera.transform.localEulerAngles;
            targetEuler.x = 0;
            targetEuler.z = 0;

            viewTransform.localEulerAngles = targetEuler;
        }
    }
}
