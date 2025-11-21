using GravityPlatformer2D.Configs;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.Characters {
    public class CharacterMovement : MonoBehaviour {
        [SerializeField] private CharacterPhysics _physics;

        private float _moveAxis;
        private CharacterMovementInfo _movementInfo;

        public void SetConfig(CharacterMovementInfo movementInfo) {
            _movementInfo = movementInfo;
        }

        public void SetMoveAxis(float moveAxis) {
            var moveVector = new Vector2(moveAxis * _movementInfo.MoveSpeed, 0f);
            _physics.SetMoveVector(moveVector);
        }

        public void Jump() {
            _physics.Jump(_movementInfo.JumpForce);
        }
    }
}
