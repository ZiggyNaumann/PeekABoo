using CardboardCore.StateMachines;
using PeekABoo.Gameplay.StateMachines.States;

namespace PeekABoo.Gameplay.StateMachines
{
    public class GameplayStateMachine : StateMachine
    {
        public GameplayStateMachine(bool enableDebugging) : base(enableDebugging)
        {
            SetInitialState<SpawnCluesState>();

            AddStaticTransition<SpawnCluesState, FadeInState>();
            AddStaticTransition<FadeInState, ActiveGameplayState>();
            AddStaticTransition<ActiveGameplayState, InspectCluesState>();
            AddStaticTransition<InspectCluesState, ActiveGameplayState>();
        }
    }
}
