using CardboardCore.DI;
using PeekABoo.Characters.NPCs;
using PeekABoo.Characters.Players;

namespace PeekABoo.Characters
{
    [Injectable]
    public class CharacterRegistry
    {
        public PlayerCharacter PlayerCharacter { get; private set; }
        public NPCCharacter NPCCharacter { get; private set; }

        public void RegisterPlayer(PlayerCharacter playerCharacter)
        {
            PlayerCharacter = playerCharacter;
        }

        public void UnregisterPlayer(PlayerCharacter playerCharacter)
        {
            if (PlayerCharacter == playerCharacter)
            {
                PlayerCharacter = null;
            }
        }

        public void RegisterNPC(NPCCharacter npcCharacter)
        {
            NPCCharacter = npcCharacter;
        }

        public void UnregisterNPC(NPCCharacter npcCharacter)
        {
            if (NPCCharacter == npcCharacter)
            {
                NPCCharacter = null;
            }
        }
    }
}
