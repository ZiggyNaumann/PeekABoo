using CardboardCore.StateMachines;
using UnityEngine;

namespace PeekABoo.Application.StateMachines.States
{
    public class BootState : State
    {
        protected override void OnEnter()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Load stuff etc.
            owningStateMachine.ToNextState();
        }

        protected override void OnExit()
        {

        }
    }
}
