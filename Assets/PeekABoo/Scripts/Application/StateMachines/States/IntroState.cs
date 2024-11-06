using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.Audio;
using PeekABoo.UI.Screens;

namespace PeekABoo.Application.StateMachines.States
{
    public class IntroState : State
    {
        [Inject] private UIManager uiManager;
        [Inject] private AudioRegistry audioRegistry;

        private IntroScreen introScreen;

        protected override void OnEnter()
        {
            introScreen = uiManager.ShowScreen<IntroScreen>();
            introScreen.IntroCompleteEvent += OnIntroComplete;

            audioRegistry.Music.PlayIntroMusic();
        }

        protected override void OnExit()
        {
            introScreen.IntroCompleteEvent -= OnIntroComplete;
            introScreen = null;
        }

        private void OnIntroComplete()
        {
            owningStateMachine.ToNextState();
        }
    }
}
