namespace PeekABoo.Characters.Players
{
    public class PlayerCharacterRotation : PlayerCharacterComponent
    {
        private PlayerCharacterInput playerCharacterInput;

        protected override void OnInjected()
        {
            base.OnInjected();

            playerCharacterInput = Owner.GetCharacterComponent<PlayerCharacterInput>();
        }
    }
}
