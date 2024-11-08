using CardboardCore.DI;
using CardboardCore.StateMachines;
using PeekABoo.Characters;
using PeekABoo.Characters.Players;
using PeekABoo.Levels;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class TeleportPlayerToLevelState : State
    {
        [Inject] private CharacterRegistry characterRegistry;
        [Inject] private LevelManager levelManager;

        protected override void OnEnter()
        {
            PlayerCharacter playerCharacter = characterRegistry.PlayerCharacter;
            levelManager.CurrentLevel.TeleportToSpawnPoint(playerCharacter.transform);

            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
