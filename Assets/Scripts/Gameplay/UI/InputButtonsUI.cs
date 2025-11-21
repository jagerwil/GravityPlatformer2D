using GravityPlatformer2D.Gameplay._Services;
using GravityPlatformer2D.Gameplay._Services.Implementations.InputProcessors;
using UnityEngine;
using Zenject;

namespace GravityPlatformer2D.Gameplay.UI {
    public class InputButtonsUI : MonoBehaviour {
        [SerializeField] private BaseMovementInputUI _movementInput;
        [SerializeField] private InputButtonUI _jumpButton;
        
        [Inject]
        private void Inject(IInputService inputService) {
            var touchProcessor = inputService.TryGetInputProcessor<TouchButtonsInputProcessor>();
            if (touchProcessor == null) {
                Debug.LogError($"{nameof(TouchButtonsInputProcessor)} was not registered as an input processor!");
                return;
            }
            
            touchProcessor.SetupButtons(_movementInput, _jumpButton);
        }
    }
}
