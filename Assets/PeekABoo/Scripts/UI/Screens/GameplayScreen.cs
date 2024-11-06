using System;
using CardboardCore.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PeekABoo.UI.Screens
{
    public class GameplayScreen : UIScreen
    {
        [SerializeField] private Image backPanel;

        protected override void OnShow()
        {

        }

        protected override void OnHide()
        {

        }

        public void PlayFadeOut(Action callback)
        {
            backPanel.DOFade(0f, 3f)
                .OnComplete(() => callback?.Invoke());
        }
    }
}
