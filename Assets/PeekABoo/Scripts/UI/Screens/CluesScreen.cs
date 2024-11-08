using System;
using CardboardCore.UI;
using DG.Tweening;
using PeekABoo.Clues;
using PeekABoo.UI.Screens.Clues;
using TMPro;
using UnityEngine;

namespace PeekABoo.UI.Screens
{
    public class CluesScreen : UIScreen
    {
        [SerializeField] private ClueElement newClue;
        [SerializeField] private TextMeshProUGUI promptText;

        private ClueElement[] clueElements;

        private int lastCollectedClueIndex;

        protected override void OnInitialize()
        {
            clueElements = GetComponentsInChildren<ClueElement>();
        }

        protected override void OnShow()
        {
            newClue.gameObject.SetActive(false);
            promptText.text = "TAB - Close Clues";
        }

        protected override void OnHide()
        {

        }

        public void ShowNewClueFound(int clueIndex, ClueConfig clueConfig)
        {
            newClue.SetClueConfig(clueConfig);
            newClue.SetFound();
            newClue.gameObject.SetActive(true);

            promptText.text = "E - Collect";

            clueElements[clueIndex].SetClueConfig(clueConfig);

            lastCollectedClueIndex = clueIndex;
        }

        public void HideNewClue(Action callback)
        {
            promptText.gameObject.SetActive(false);

            ClueElement unlockedClueElement = clueElements[lastCollectedClueIndex];
            unlockedClueElement.SetImageVisible(false);

            newClue.transform.DOMove(unlockedClueElement.transform.position, 1f)
                .SetEase(Ease.InOutQuad)
                .OnComplete(() =>
                {
                    promptText.gameObject.SetActive(true);
                    promptText.text = "TAB - Close Clues";

                    unlockedClueElement.SetImageVisible(true);
                    unlockedClueElement.SetFound();
                    unlockedClueElement.transform.DOPunchScale(Vector3.one * 2f, 0.5f, 2, 0.3f);

                    callback?.Invoke();
                });
        }

        public void ResetClues()
        {
            foreach (ClueElement clueElement in clueElements)
            {
                clueElement.ResetState();
            }

            lastCollectedClueIndex = 0;
        }
    }
}
