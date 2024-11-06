using CardboardCore.DI;
using CardboardCore.StateMachines;
using PeekABook.Input;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class EnableControlsState : State
    {
        [Inject] private InputManager inputManager;

        protected override void OnEnter()
        {
            inputManager.EnablePlayer();
        }

        protected override void OnExit()
        {

        }
    }
}
