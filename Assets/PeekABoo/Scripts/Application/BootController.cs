using PeekABoo.Application.StateMachines;
using UnityEngine;

namespace PeekABoo.Application
{
    public class BootController : MonoBehaviour
    {
        private ApplicationStateMachine applicationStateMachine;

        private void Awake()
        {
            applicationStateMachine = new ApplicationStateMachine(true);
        }

        private void Start()
        {
            applicationStateMachine.Start();
        }

        private void OnDestroy()
        {
            applicationStateMachine.Stop();
            applicationStateMachine = null;
        }
    }
}
