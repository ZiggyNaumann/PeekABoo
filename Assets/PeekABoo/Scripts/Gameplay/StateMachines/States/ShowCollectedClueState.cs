using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.Clues;
using PeekABoo.UI.Screens;
using PeekABoo.Input;
using UnityEngine.InputSystem;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class ShowCollectedClueState : State
    {
        [Inject] private UIManager uiManager;
        [Inject] private CluesManager cluesManager;
        [Inject] private InputManager inputManager;

        private CluesScreen cluesScreen;

        protected override void OnEnter()
        {
            cluesScreen = uiManager.ShowScreen<CluesScreen>();

            cluesScreen.ShowNewClueFound(cluesManager.ClueProgress.CollectedAmount - 1,
                                         cluesManager.ClueProgress.CollectedClues[cluesManager.ClueProgress.CollectedAmount - 1]);

            inputManager.EnableClues();
            inputManager.Clues.HideNewFoundClue.performed += OnHideNewFoundClue;
        }

        protected override void OnExit()
        {
            inputManager.DisableClues();
        }

        private void OnHideNewFoundClue(InputAction.CallbackContext obj)
        {
            inputManager.Clues.HideNewFoundClue.performed -= OnHideNewFoundClue;
            cluesScreen.HideNewClue(owningStateMachine.ToNextState);
        }
    }
}
