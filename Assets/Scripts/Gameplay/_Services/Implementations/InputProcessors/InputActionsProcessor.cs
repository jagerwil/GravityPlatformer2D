using System;
using R3;

namespace GravityPlatformer2D.Gameplay._Services.Implementations.InputProcessors {
    public class InputActionsProcessor : IInputProcessor {
        private readonly ReactiveProperty<float> _moveVector = new();
        private readonly InputActions _inputActions = new();
        
        public ReadOnlyReactiveProperty<float> MoveVector => _moveVector;
        public event Action onJumpButtonPressed;

        public InputActionsProcessor() {
            _inputActions.Player.Move.performed += (ctx) => {
                _moveVector.Value = ctx.ReadValue<float>();
            };

            _inputActions.Player.Move.canceled += _ => {
                _moveVector.Value = 0f;
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
