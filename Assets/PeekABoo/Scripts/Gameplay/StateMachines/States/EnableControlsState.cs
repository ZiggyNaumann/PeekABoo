using CardboardCore.DI;
using CardboardCore.StateMachines;
using CardboardCore.UI;
using PeekABoo.Characters;
using PeekABoo.Characters.Players;
using PeekABoo.UI.Screens;
using PeekABook.Input;

namespace PeekABoo.Gameplay.StateMachines.States
{
    public class EnableControlsState : State
    {
        [Inject] private InputManager inputManager;
        [Inject] private UIManager uiManager;
        [Inject] private CharacterRegistry characterRegistry;

        protected override void OnEnter()
        {
            inputManager.EnablePlayer();

            characterRegistry.PlayerCharacter.GetCharacterComponent<PlayerCharacterStamina>()
                .SetGameplayScreenReference(uiManager.GetScreen<GameplayScreen>());
        }

        protected override void OnExit()
        {

        }
    }
}
