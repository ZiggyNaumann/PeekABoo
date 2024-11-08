using System;
using CardboardCore.UI;
using DG.Tweening;
using PeekABoo.UI.Screens.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace PeekABoo.UI.Screens
{
    public class GameplayScreen : UIScreen
    {
        [SerializeField] private Image backPanel;
        [SerializeField] private Image staminaBar;

        [SerializeField] private InteractPromptElement interactPromptElement;

        private float staminaBarWidth;

        private Tween fadeOutTween;
        private Tween fadeInTween;

        protected override void OnShow()
        {
            staminaBarWidth = staminaBar.rectTransform.sizeDelta.x;
            staminaBar.DOFade(0, 0);
        }

        protected override void OnHide()
        {
            staminaBar.rectTransform.sizeDelta = new Vector2(staminaBarWidth, staminaBar.rectTransform.sizeDelta.y);
        }

        public void PlayFadeOut(Action callback)
        {
            backPanel.DOFade(0f, 3f)
                .OnComplete(() => callback?.Invoke());
        }

        public void UpdateStaminaBar(float normalizedValue)
        {
            if (normalizedValue >= 1)
            {
                normalizedValue = 1;

                fadeInTween?.Kill();
                fadeInTween = null;

                fadeOutTween ??= staminaBar.DOFade(0f, 0.5f).SetDelay(2f);
            }
            else
            {
                fadeOutTween?.Kill();
                fadeOutTween = null;

                fadeInTween ??= staminaBar.DOFade(1f, 0.5f);
            }

            staminaBar.rectTransform.sizeDelta = new Vector2(staminaBarWidth * normalizedValue, staminaBar.rectTransform.sizeDelta.y);
        }

        public void ShowExhaustedState()
        {
            staminaBar.color = Color.red;
        }

        public void HideExhaustedState()
        {
            staminaBar.color = Color.white;
        }

        public void ShowInteractPrompt(Transform interactableTransform)
        {
            interactPromptElement.Show(interactableTransform);
        }

        public void HideInteractPrompt()
        {
            interactPromptElement.Hide();
        }
    }
}
