using CardboardCore.StateMachines;
using PeekABoo.Gameplay.StateMachines.States;

namespace PeekABoo.Gameplay.StateMachines
{
    public class GameplayStateMachine : StateMachine
    {
        public GameplayStateMachine(bool enableDebugging) : base(enableDebugging)
        {
            SetInitialState<SpawnLevelState>();

            AddStaticTransition<SpawnLevelState, SpawnCluesState>();
            AddStaticTransition<SpawnCluesState, TeleportPlayerToLevelState>();
            AddStaticTransition<TeleportPlayerToLevelState, FadeInState>();
            AddStaticTransition<FadeInState, ActiveGameplayState>();

            AddFreeFlowTransition<ActiveGameplayState, InspectCluesState>();
            AddFreeFlowTransition<ActiveGameplayState, ShowCollectedClueState>();

            AddStaticTransition<ShowCollectedClueState, InspectCluesState>();
            AddStaticTransition<InspectCluesState, ActiveGameplayState>();
        }
    }
}
