using CardboardCore.DI;
using CardboardCore.Utilities;

namespace PeekABook.Input
{
    [Injectable]
    public class InputManager
    {
        private PeekABooActions spaceLifeActions;

        public PeekABooActions.PlayerActions Player => spaceLifeActions.Player;
        public PeekABooActions.UIActions UI => spaceLifeActions.UI;

        public InputManager()
        {
            spaceLifeActions = new PeekABooActions();
            spaceLifeActions.Disable();

            DisablePlayer();
            DisableUI();
        }

        ~InputManager()
        {
            spaceLifeActions?.Dispose();
            spaceLifeActions = null;
        }

        public void Enable()
        {
            Log.Write("Enabling Input...");
            spaceLifeActions.Enable();
        }

        public void Disable()
        {
            Log.Write("Disabling Input...");
            spaceLifeActions.Disable();
        }

        public void EnablePlayer()
        {
            Log.Write("Enabling Player Input...");
            Player.Enable();
        }

        public void DisablePlayer()
        {
            Log.Write("Disabling Player Input...");
            Player.Disable();
        }

        public void EnableUI()
        {
            Log.Write("Enabling UI Input...");
            UI.Enable();
        }

        public void DisableUI()
        {
            Log.Write("Disabling UI Input...");
            UI.Disable();
        }
    }
}
