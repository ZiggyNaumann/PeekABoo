using CardboardCore.StateMachines;

namespace PeekABoo.Application.StateMachines.States
{
    public class LoadLevelState : State
    {
        protected override void OnEnter()
        {
            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
