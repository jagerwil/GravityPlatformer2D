using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GravityPlatformer2D.Gameplay.UI {
    public class InputButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
        public event Action onButtonPressed;
        public event Action onButtonReleased;

        public bool IsPressed { get; private set; }
        
        public void OnPointerDown(PointerEventData eventData) {
            IsPressed = true;
            onButtonPressed?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData) {
            IsPressed = false;
            onButtonReleased?.Invoke();
        }
    }
}
