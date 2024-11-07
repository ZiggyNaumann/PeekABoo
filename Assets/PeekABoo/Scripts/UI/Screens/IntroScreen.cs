using System;
using System.Collections;
using CardboardCore.UI;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace PeekABoo.UI.Screens
{
    public class IntroScreen : UIScreen
    {
        [SerializeField] private TextMeshProUGUI introText;
        [SerializeField] private string[] words;

        public event Action IntroCompleteEvent;

        protected override void OnShow()
        {
            introText.transform.localScale = Vector3.one;
            StartCoroutine(UpdateText());
        }

        protected override void OnHide()
        {

        }

        private IEnumerator UpdateText()
        {
            for (int i = 0; i < words.Length; i++)
            {
                introText.text = words[i];
                // TODO: Play SFX
                yield return new WaitForSeconds(2f);
            }

            Sequence sequence = DOTween.Sequence();

            sequence.Append(introText.transform.DOScale(2f, 4f));
            sequence.Insert(2f, introText.DOFade(0f, 1f));
            sequence.OnComplete(() => IntroCompleteEvent?.Invoke());
        }
    }
}
