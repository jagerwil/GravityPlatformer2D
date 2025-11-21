using GravityPlatformer2D.Gameplay._Services;
using R3;
using UnityEngine;
using Zenject;

namespace GravityPlatformer2D.Gameplay.Characters.Player {
    public class PlayerInputController : MonoBehaviour {
        [SerializeField] private CharacterMovement _characterMovement;
        
        [Inject] private IInputService _inputService;

        private readonly CompositeDisposable _disposables = new();

        private void Awake() {
            _inputService.MoveAxis
                         .Subscribe(MoveAxisChanged)
                         .AddTo(_disposables);

            _inputService.onJumpButtonPressed += JumpButtonPressed;
        }

        private void OnDestroy() {
            if (_inputService != null) {
                _inputService.onJumpButtonPressed -= JumpButtonPressed;
            }
        }

        private void MoveAxisChanged(float moveAxis) {
            _characterMovement.SetMoveAxis(moveAxis);
        }

        private void JumpButtonPressed() {
            _characterMovement.Jump();
        }
    }
}
