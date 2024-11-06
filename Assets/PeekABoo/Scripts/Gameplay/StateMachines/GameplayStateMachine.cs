using CardboardCore.StateMachines;
using PeekABoo.Gameplay.StateMachines.States;

namespace PeekABoo.Gameplay.StateMachines
{
    public class GameplayStateMachine : StateMachine
    {
        public GameplayStateMachine(bool enableDebugging) : base(enableDebugging)
        {
            SetInitialState<FadeInState>();

            AddStaticTransition<FadeInState, EnableControlsState>();
        }
    }
}
