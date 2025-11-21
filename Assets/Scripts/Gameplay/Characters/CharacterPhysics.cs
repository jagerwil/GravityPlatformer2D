using System;
using GravityPlatformer2D.Gameplay.Gravity.Receivers;
using Jagerwil.Extensions;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.Characters {
    public class CharacterPhysics : MonoBehaviour {
        [SerializeField] private GravityReceiver _gravityReceiver;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private Rigidbody2D _rigidbody;

        private Vector2 _moveVector;
        private Vector2 _gravityDirection;
        private Vector2 _gravityVelocity;

        private void FixedUpdate() {
            var gravityAcceleration = _gravityReceiver.GetGravityAcceleration();
            if (gravityAcceleration.ApproximatelyZero()) {
                Debug.LogWarning("Gravity acceleration = 0 is not supported!");
            }

            _gravityDirection = gravityAcceleration.normalized;
            var angle = Vector2.SignedAngle(Vector3.down, _gravityDirection);
            var deltaTime = Time.fixedDeltaTime;
            
            _gravityVelocity = GetGravityVelocity(gravityAcceleration, deltaTime);
            var moveVelocity = GetMovementVelocity(angle);
            
            Debug.DrawLine(_rigidbody.position, _rigidbody.position + _gravityVelocity, Color.red);
            Debug.DrawLine(_rigidbody.position, _rigidbody.position + moveVelocity, Color.orange);

            _rigidbody.linearVelocity = _gravityVelocity + moveVelocity;
            _rigidbody.rotation = angle;
        }

        public void SetMoveVector(Vector2 moveVector) {
            _moveVector = moveVector;
        }

        public void Jump(float jumpForce) {
            if (!_groundChecker.IsColliding) {
                return;
            }

            var jumpDirection = -1f * _gravityDirection;
            
            _groundChecker.IgnoreCollisionsTemporarily();
            _gravityVelocity += jumpDirection * jumpForce;
        }

        private Vector2 GetGravityVelocity(Vector2 gravityAcceleration, float deltaTime) {
            if (_groundChecker.IsColliding) {
                return Vector2.zero;
            }

            var gravityVelocity = (Vector2)Vector3.Project(_gravityVelocity, gravityAcceleration);
            gravityVelocity += gravityAcceleration * deltaTime;
            //var gravityVelocity = _gravityVelocity + gravityAcceleration * deltaTime;
            return gravityVelocity;
        }

        private Vector2 GetMovementVelocity(float angle) {
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            return (Vector2)(rotation * _moveVector);
        }
    }
}
