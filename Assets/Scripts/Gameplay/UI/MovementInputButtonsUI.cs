using R3;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.UI {
    public class MovementInputButtonsUI : BaseMovementInputUI {
        [SerializeField] private InputButtonUI _leftButton;
        [SerializeField] private InputButtonUI _rightButton;

        private readonly ReactiveProperty<float> _inputAxis = new();
        
        public override ReadOnlyReactiveProperty<float> InputAxis => _inputAxis;

        private void Awake() {
            _leftButton.onButtonPressed += RecalculateMovementAxis;
            _leftButton.onButtonReleased += RecalculateMovementAxis;
            
            _rightButton.onButtonPressed += RecalculateMovementAxis;
            _rightButton.onButtonReleased += RecalculateMovementAxis;
        }

        private void RecalculateMovementAxis() {
            var leftButtonAxis = _leftButton.IsPressed ? -1f : 0f;
            var rightButtonAxis = _rightButton.IsPressed ? 1f : 0f;
            _inputAxis.Value = leftButtonAxis + rightButtonAxis;
        }
    }
}
