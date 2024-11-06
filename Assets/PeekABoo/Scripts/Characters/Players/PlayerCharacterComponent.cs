namespace PeekABoo.Characters.Players
{
    public abstract class PlayerCharacterComponent : CharacterComponent
    {
        public new PlayerCharacter Owner => base.Owner as PlayerCharacter;
    }
}
