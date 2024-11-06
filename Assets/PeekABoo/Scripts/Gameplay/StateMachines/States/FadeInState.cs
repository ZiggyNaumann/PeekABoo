using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.Audio;
using PeekABoo.UI.Screens;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class FadeInState : State
    {
        [Inject] private UIManager uiManager;
        [Inject] private AudioRegistry audioRegistry;

        private GameplayScreen gameplayScreen;

        protected override void OnEnter()
        {
            gameplayScreen = uiManager.ShowScreen<GameplayScreen>();
            gameplayScreen.PlayFadeOut(owningStateMachine.ToNextState);

            audioRegistry.Music.FadeOut(2f);
        }

        protected override void OnExit()
        {

        }
    }
}
