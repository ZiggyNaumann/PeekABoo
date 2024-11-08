using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.Clues;
using PeekABoo.UI.Screens;
using PeekABoo.Input;
using UnityEngine.InputSystem;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class ActiveGameplayState : State
    {
        [Inject] private InputManager inputManager;
        [Inject] private UIManager uiManager;
        [Inject] private CluesManager cluesManager;

        protected override void OnEnter()
        {
            inputManager.EnablePlayer();
            inputManager.Player.ShowClues.performed += OnShowClues;

            // In case we're not transitioning in via FadeInState
            GameplayScreen gameplayScreen = uiManager.ShowScreen<GameplayScreen>();
            gameplayScreen.ShowCluesText();

            cluesManager.ClueCollectedEvent += OnClueCollected;
        }

        protected override void OnExit()
        {
            inputManager.DisablePlayer();
            inputManager.Player.ShowClues.performed -= OnShowClues;

            cluesManager.ClueCollectedEvent -= OnClueCollected;
        }

        private void OnShowClues(InputAction.CallbackContext obj)
        {
            owningStateMachine.ToState<InspectCluesState>();
        }

        private void OnClueCollected(Clue clue)
        {
            owningStateMachine.ToState<ShowCollectedClueState>();
        }
    }
}
