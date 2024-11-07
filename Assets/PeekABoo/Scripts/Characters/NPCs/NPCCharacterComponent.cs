namespace PeekABoo.Characters.NPCs
{
    public abstract class NPCCharacterComponent : CharacterComponent
    {
        public new NPCCharacter Owner => base.Owner as NPCCharacter;
    }
}
