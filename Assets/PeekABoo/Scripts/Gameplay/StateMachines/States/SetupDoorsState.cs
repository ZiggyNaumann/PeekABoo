using CardboardCore.DI;
using CardboardCore.StateMachines;
using PeekABoo.Levels;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class SetupDoorsState : State
    {
        [Inject] private LevelManager levelManager;

        protected override void OnEnter()
        {
            levelManager.CurrentLevel.SetupDoors();
            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
