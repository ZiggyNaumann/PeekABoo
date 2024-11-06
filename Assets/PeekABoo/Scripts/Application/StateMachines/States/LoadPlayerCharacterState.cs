using CardboardCore.StateMachines;

namespace PeekABoo.Application.StateMachines.States
{
    public class LoadPlayerCharacterState : State
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
