using CardboardCore.Cameras.VirtualCameras;
using CardboardCore.DI;
using CardboardCore.UI;
using UnityEngine;
using UnityEngine.UI;

namespace PeekABoo.UI.Screens.Gameplay
{
    public class InteractPromptElement : CardboardCoreBehaviour
    {
        [Inject] private VirtualCameraManager virtualCameraManager;
        [Inject] private UIManager uiManager;

        private Transform target;
        private RectTransform myRectTransform;

        private Vector2 screenDimensions;

        protected override InjectTiming MyInjectTiming => InjectTiming.Start;

        protected override void OnInjected()
        {
            myRectTransform = GetComponent<RectTransform>();

            screenDimensions = uiManager.UICanvas.GetComponent<CanvasScaler>().referenceResolution;

            Hide();
        }

        protected override void OnReleased()
        {

        }

        private void Update()
        {
            SetPosition();
        }

        private void SetPosition()
        {
            if (target == null)
            {
                return;
            }

            Vector3 screenPoint = virtualCameraManager.CameraController.Camera.WorldToScreenPoint(target.position);
            screenPoint.x -= Screen.width / 2;
            screenPoint.y -= Screen.height / 2;

            Vector2 normalizedScreenPoint = new Vector2(screenPoint.x / Screen.width, screenPoint.y / Screen.height);

            Vector2 worldScreenPoint = new Vector2(normalizedScreenPoint.x * screenDimensions.x,
                                                   normalizedScreenPoint.y * screenDimensions.y);

            myRectTransform.anchoredPosition = worldScreenPoint;
        }

        public void Show(Transform target)
        {
            this.target = target;
            gameObject.SetActive(true);

            SetPosition();
        }

        public void Hide()
        {
            target = null;
            gameObject.SetActive(false);
        }
    }
}
