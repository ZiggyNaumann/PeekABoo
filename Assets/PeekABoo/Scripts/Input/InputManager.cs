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
        public PeekABooActions.IntroActions Intro => spaceLifeActions.Intro;
        public PeekABooActions.CluesActions Clues => spaceLifeActions.Clues;

        public InputManager()
        {
            spaceLifeActions = new PeekABooActions();
            spaceLifeActions.Disable();

            DisablePlayer();
            DisableUI();
            DisableIntro();
            DisableClues();
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

        public void EnableIntro()
        {
            Log.Write("Enabling Intro Input...");
            Intro.Enable();
        }

        public void DisableIntro()
        {
            Log.Write("Disabling Intro Input...");
            Intro.Disable();
        }

        public void EnableClues()
        {
            Log.Write("Enabling Clues Input...");
            Clues.Enable();
        }

        public void DisableClues()
        {
            Log.Write("Disabling Clues Input...");
            Clues.Disable();
        }
    }
}
