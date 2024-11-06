using CardboardCore.StateMachines;
using PeekABoo.Application.StateMachines.States;

namespace PeekABoo.Application.StateMachines
{
    public class ApplicationStateMachine : StateMachine
    {
        public ApplicationStateMachine(bool enableDebugging) : base(enableDebugging)
        {
            SetInitialState<BootState>();

            AddStaticTransition<BootState, IntroState>();
            AddStaticTransition<IntroState, LoadLevelState>();
            AddStaticTransition<LoadLevelState, LoadPlayerCharacterState>();
            AddStaticTransition<LoadPlayerCharacterState, GameplayState>();
        }
    }
}
