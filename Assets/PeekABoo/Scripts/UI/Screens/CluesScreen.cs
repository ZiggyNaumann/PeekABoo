using CardboardCore.UI;
using PeekABoo.UI.Screens.Clues;

namespace PeekABoo.UI.Screens
{
    public class CluesScreen : UIScreen
    {
        private ClueElement[] clueElements;

        protected override void OnShow()
        {
            clueElements = GetComponentsInChildren<ClueElement>();
        }

        protected override void OnHide()
        {

        }
    }
}
