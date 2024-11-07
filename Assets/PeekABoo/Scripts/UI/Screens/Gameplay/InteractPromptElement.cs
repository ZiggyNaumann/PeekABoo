using CardboardCore.Cameras.VirtualCameras;
using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.UI.Screens.Gameplay
{
    public class InteractPromptElement : CardboardCoreBehaviour
    {
        [Inject] private VirtualCameraManager virtualCameraManager;

        private Transform target;
        private RectTransform myRectTransform;

        protected override void OnInjected()
        {
            myRectTransform = GetComponent<RectTransform>();
            Hide();
        }

        protected override void OnReleased()
        {

        }

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            Vector3 screenPoint = virtualCameraManager.CameraController.Camera.WorldToScreenPoint(target.position);
            screenPoint.x -= Screen.width / 2;
            screenPoint.y -= Screen.height / 2;
            myRectTransform.anchoredPosition = screenPoint;
        }

        public void Show(Transform target)
        {
            this.target = target;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            target = null;
            gameObject.SetActive(false);
        }
    }
}
