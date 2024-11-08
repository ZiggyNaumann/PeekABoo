using System;
using CardboardCore.DI;
using PeekABoo.Interacting;
using UnityEngine;

namespace PeekABoo.Levels.Rooms.Paintings
{
    public class Painting : CardboardCoreBehaviour
    {
        private Interactable interactable;
        private Material materialInstance;

        public event Action PaintingInteractEvent;

        protected override void OnInjected()
        {
            interactable = GetComponent<Interactable>();
            interactable.InteractEvent += OnInteract;

            Renderer renderer = GetComponentInChildren<Renderer>();
            materialInstance = new Material(renderer.material);

            renderer.material = materialInstance;
        }

        protected override void OnReleased()
        {

        }

        private void OnInteract()
        {
            PaintingInteractEvent?.Invoke();
        }

        public void SetTexture(Sprite sprite)
        {
            materialInstance.mainTexture = sprite.texture;
        }
    }
}
