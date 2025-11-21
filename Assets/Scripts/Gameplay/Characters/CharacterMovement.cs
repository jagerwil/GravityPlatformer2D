using GravityPlatformer2D.Configs;
using GravityPlatformer2D.Gameplay.Gravity;
using GravityPlatformer2D.Gameplay.Gravity.Receivers;
using UnityEngine;
using Zenject;

namespace GravityPlatformer2D.Gameplay.Characters {
    public class CharacterMovement : MonoBehaviour {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GravityReceiver _gravityReceiver;

        private float _moveAxis;
        private PlayerMovementInfo _movementInfo;

        [Inject]
        private void Inject(PlayerConfig config) {
            _movementInfo = config.Movement;
        }

        public void SetMoveAxis(float moveAxis) {
            _moveAxis = moveAxis;
        }

        public Vector2 GetMoveVector() {
            return new Vector2(_moveAxis * _movementInfo.MoveSpeed, 0f);
        }

        public void Jump() {
            Debug.Log("Jump!");
        }
    }
}
