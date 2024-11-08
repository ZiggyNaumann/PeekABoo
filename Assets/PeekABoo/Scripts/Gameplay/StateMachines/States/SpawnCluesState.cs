using CardboardCore.DI;
using CardboardCore.StateMachines;
using PeekABoo.Clues;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class SpawnCluesState : State
    {
        [Inject] private ClueRegistry clueRegistry;
        [Inject] private ClueFactory clueFactory;

        protected override void OnEnter()
        {
            clueFactory.InitLevelClues(clueRegistry.ClueSpots);
            clueFactory.SpawnAllClues();

            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
