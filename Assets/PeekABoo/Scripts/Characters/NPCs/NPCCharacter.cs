using CardboardCore.DI;

namespace PeekABoo.Characters.NPCs
{
    public class NPCCharacter : Character
    {
        [Inject] private CharacterRegistry characterRegistry;

        protected override void OnInjected()
        {
            characterRegistry.RegisterNPC(this);

            base.OnInjected();
        }

        protected override void OnReleased()
        {
            characterRegistry.RegisterNPC(null);

            base.OnReleased();
        }
    }
}
