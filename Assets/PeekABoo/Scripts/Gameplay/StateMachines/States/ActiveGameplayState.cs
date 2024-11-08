using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.UI.Screens;
using PeekABoo.Input;
using UnityEngine.InputSystem;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class ActiveGameplayState : State
    {
        [Inject] private InputManager inputManager;
        [Inject] private UIManager uiManager;

        protected override void OnEnter()
        {
            inputManager.EnablePlayer();

            // In case we're not transitioning in via FadeInState
            GameplayScreen gameplayScreen = uiManager.ShowScreen<GameplayScreen>();
            gameplayScreen.ShowCluesText();

            inputManager.Player.ShowClues.performed += OnShowClues;
        }

        protected override void OnExit()
        {
            inputManager.Player.ShowClues.performed -= OnShowClues;
        }

        private void OnShowClues(InputAction.CallbackContext obj)
        {
            owningStateMachine.ToNextState();
        }
    }
}
