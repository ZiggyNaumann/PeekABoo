using CardboardCore.DI;
using CardboardCore.StateMachines;
using PeekABoo.Clues;
using PeekABoo.Levels;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class SpawnCluesState : State
    {
        [Inject] private ClueRegistry clueRegistry;
        [Inject] private ClueFactory clueFactory;
        [Inject] private LevelManager levelManager;

        protected override void OnEnter()
        {
            // Get one clue spot per room
            ClueSpot[] clueSpots = levelManager.CurrentLevel.GetOneClueSpotPerRoom();

            clueFactory.InitLevelClues(clueSpots);
            clueFactory.SpawnAllClues();

            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
