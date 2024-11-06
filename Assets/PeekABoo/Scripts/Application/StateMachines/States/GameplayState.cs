using CardboardCore.StateMachines;
using PeekABoo.Gameplay.StateMachines;

namespace PeekABoo.Application.StateMachines.States
{
    public class GameplayState : State
    {
        private GameplayStateMachine gameplayStateMachine;

        protected override void OnEnter()
        {
            gameplayStateMachine = new GameplayStateMachine(true);
            gameplayStateMachine.Start();

            gameplayStateMachine.StoppedEvent += OnGameplayStateMachineStopped;
        }

        protected override void OnExit()
        {

        }


        private void OnGameplayStateMachineStopped()
        {
            // TODO: Check why the gameplay was stopped, move on accordingly
        }
    }
}
