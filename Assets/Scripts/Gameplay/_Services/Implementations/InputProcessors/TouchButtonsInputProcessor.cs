using System;
using GravityPlatformer2D.Gameplay.UI;
using R3;

namespace GravityPlatformer2D.Gameplay._Services.Implementations.InputProcessors {
    public class TouchButtonsInputProcessor : IInputProcessor, IDisposable {
        private readonly CompositeDisposable _disposables = new();
        private readonly ReactiveProperty<float> _moveAxis = new();

        private BaseMovementInputUI _movementInput;
        private InputButtonUI _jumpButton;
        private bool _isActive;
        
        public ReadOnlyReactiveProperty<float> MoveAxis => _moveAxis;
        public event Action onJumpButtonPressed;

        public void SetupButtons(BaseMovementInputUI movementInput, InputButtonUI jumpButton) {
            _movementInput = movementInput;
            _jumpButton = jumpButton;
            
            movementInput.InputAxis
                         .Subscribe(InputAxisChanged)
                         .AddTo(_disposables);

            jumpButton.onButtonPressed += JumpButtonPressed;
        }

        public void Dispose() {
            if (_jumpButton) {
                _jumpButton.onButtonPressed -= JumpButtonPressed;
            }
            _disposables?.Dispose();
        }
        
        public void Enable() {
            if (_movementInput) {
                _moveAxis.Value = _movementInput.InputAxis.CurrentValue;
            }
            _isActive = true;
        }
        
        public void Disable() {
            if (_movementInput) {
                _moveAxis.Value = 0f;
            }
            _isActive = false;
        }

        private void InputAxisChanged(float inputAxis) {
            if (_isActive) {
                _moveAxis.Value = inputAxis;
            }
        }

        private void JumpButtonPressed() {
            if (_isActive) {
                onJumpButtonPressed?.Invoke();
            }
        }
    }
}
