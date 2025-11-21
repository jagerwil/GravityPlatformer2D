using System;
using R3;

namespace GravityPlatformer2D.Gameplay._Services.Implementations.InputProcessors {
    public class InputActionsProcessor : IInputProcessor {
        private readonly ReactiveProperty<float> _moveAxis = new();
        private readonly InputActions _inputActions = new();
        
        public ReadOnlyReactiveProperty<float> MoveAxis => _moveAxis;
        public event Action onJumpButtonPressed;

        public InputActionsProcessor() {
            _inputActions.Player.Move.performed += (ctx) => {
                _moveAxis.Value = ctx.ReadValue<float>();
            };

            _inputActions.Player.Move.canceled += _ => {
                _moveAxis.Value = 0f;
            };

            _inputActions.Player.Jump.performed += _ => {
                onJumpButtonPressed?.Invoke();
            };
        }

        public void Enable() {
            _inputActions.Enable();
        }

        public void Disable() {
            _inputActions.Disable();
        }
    }
}
