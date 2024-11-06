using CardboardCore.DI;

namespace PeekABoo.Characters.Players
{
    public class PlayerCharacter : Character
    {
        [Inject] private CharacterRegistry characterRegistry;

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
