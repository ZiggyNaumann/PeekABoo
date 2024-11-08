using System;
using System.Collections;
using CardboardCore.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PeekABoo.UI.Screens
{
    public class IntroScreen : UIScreen
    {
        [SerializeField] private Image backPanel;
        [SerializeField] private TextMeshProUGUI introText;
        [SerializeField] private float timeBetweenWords = 2f;
        [SerializeField] private float fullLogoTime = 3f;
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

                yield return new WaitForSeconds(timeBetweenWords);
            }

            introText.gameObject.SetActive(false);
            backPanel.color = Color.black;

            yield return new WaitForSeconds(fullLogoTime);

            IntroCompleteEvent?.Invoke();
        }
    }
}
