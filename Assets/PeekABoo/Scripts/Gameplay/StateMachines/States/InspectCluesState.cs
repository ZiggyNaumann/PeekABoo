using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.UI.Screens;
using PeekABoo.Input;
using UnityEngine.InputSystem;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class InspectCluesState : State
    {
        [Inject] private InputManager inputManager;
        [Inject] private UIManager uiManager;

        private CluesScreen cluesScreen;

        protected override void OnEnter()
        {
            inputManager.DisablePlayer();
            inputManager.EnableClues();

            inputManager.Clues.CloseClues.performed += OnCloseClues;

            cluesScreen = uiManager.ShowScreen<CluesScreen>();
        }

        protected override void OnExit()
        {
            inputManager.Clues.CloseClues.performed -= OnCloseClues;
        }

        private void OnCloseClues(InputAction.CallbackContext obj)
        {
            owningStateMachine.ToNextState();
        }
    }
}
