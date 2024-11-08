using System;
using PeekABoo.Clues;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PeekABoo.UI.Screens.Clues
{
    public enum ClueState
    {
        NotFound,
        Found
    }

    public class ClueElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI questionMarkText;
        [SerializeField] private Image clueImage;

        private ClueState clueState;

        private void Awake()
        {
            clueState = ClueState.NotFound;
            UpdateView();
        }

        private void UpdateView()
        {
            questionMarkText.gameObject.SetActive(clueState == ClueState.NotFound);
            clueImage.gameObject.SetActive(clueState == ClueState.Found);
        }

        public void SetClueConfig(ClueConfig clueConfig)
        {
            clueImage.sprite = clueConfig.Sprite;
        }

        public void SetFound()
        {
            clueState = ClueState.Found;
            UpdateView();
        }

        public void ResetState()
        {
            clueState = ClueState.NotFound;
            UpdateView();
        }

        public void SetImageVisible(bool isVisible)
        {
            clueImage.enabled = isVisible;
        }
    }
}
