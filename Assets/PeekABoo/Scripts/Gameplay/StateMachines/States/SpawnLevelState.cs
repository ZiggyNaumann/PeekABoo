using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.Clues;
using PeekABoo.Levels;
using PeekABoo.UI.Screens;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class SpawnLevelState : State
    {
        [Inject] private LevelManager levelManager;
        [Inject] private CluesManager cluesManager;
        [Inject] private UIManager uiManager;

        protected override void OnEnter()
        {
            // TODO: Track level progress and load the correct level
            levelManager.SpawnLevel(0);

            cluesManager.ClueProgress.Reset();
            uiManager.GetScreen<CluesScreen>().ResetClues();

            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
