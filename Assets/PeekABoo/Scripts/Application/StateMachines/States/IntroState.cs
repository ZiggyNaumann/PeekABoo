using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.Audio;
using PeekABoo.UI.Screens;
using PeekABoo.Input;
using UnityEngine.InputSystem;

namespace PeekABoo.Application.StateMachines.States
{
    public class IntroState : State
    {
        [Inject] private UIManager uiManager;
        [Inject] private AudioRegistry audioRegistry;
        [Inject] private InputManager inputManager;

        private IntroScreen introScreen;

        protected override void OnEnter()
        {
            introScreen = uiManager.ShowScreen<IntroScreen>();
            introScreen.IntroCompleteEvent += OnIntroComplete;

            audioRegistry.Music.PlayIntroMusic();

            inputManager.Intro.Enable();
            inputManager.Intro.Skip.performed += OnPerformed;
        }

        protected override void OnExit()
        {
            introScreen.IntroCompleteEvent -= OnIntroComplete;
            introScreen = null;

            inputManager.Intro.Disable();
            inputManager.Intro.Skip.performed -= OnPerformed;
        }

        private void OnIntroComplete()
        {
            owningStateMachine.ToNextState();
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            owningStateMachine.ToNextState();
        }
    }
}
