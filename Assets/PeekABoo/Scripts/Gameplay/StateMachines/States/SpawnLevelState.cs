using CardboardCore.DI;
using CardboardCore.StateMachines;
using PeekABoo.Levels;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class SpawnLevelState : State
    {
        [Inject] private LevelManager levelManager;

        protected override void OnEnter()
        {
            levelManager.SpawnLevel(0);
            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
