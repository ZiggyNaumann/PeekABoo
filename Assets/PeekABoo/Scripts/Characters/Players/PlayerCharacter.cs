using CardboardCore.Cameras.VirtualCameras;
using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Characters.Players
{
    public class PlayerCharacter : Character
    {
        [Inject] private CharacterRegistry characterRegistry;

        [SerializeField] private VirtualCamera firstPersonCamera;

        public VirtualCamera FirstPersonCamera => firstPersonCamera;

        protected override void OnInjected()
        {
            base.OnInjected();

            characterRegistry.RegisterPlayer(this);
        }

        protected override void OnReleased()
        {
            characterRegistry.RegisterPlayer(null);

            base.OnReleased();
        }
    }
}
