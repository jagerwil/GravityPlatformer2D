using GravityPlatformer2D.Gameplay.Gravity;
using GravityPlatformer2D.Gameplay.Gravity.Receivers;
using Jagerwil.Extensions;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.Characters {
    public class CharacterPhysics : MonoBehaviour {
        [SerializeField] private GravityReceiver _gravityReceiver;
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void FixedUpdate() {
            Debug.Log("Gravity receiver fixed update!");
            var gravityAcceleration = _gravityReceiver.GetGravityAcceleration();
            if (gravityAcceleration.ApproximatelyZero()) {
                Debug.LogWarning("Gravity acceleration = 0 is not supported!");
            }

            var velocity = _rigidbody.linearVelocity;
            var angle = Vector2.SignedAngle(Vector3.down, gravityAcceleration);
            
            var gravityVelocity = GetGravityVelocity(velocity, gravityAcceleration);
            var moveVelocity = GetMovementVelocity(angle, gravityAcceleration);
            
            Debug.DrawLine(_rigidbody.position, _rigidbody.position + gravityVelocity, Color.red);
            Debug.DrawLine(_rigidbody.position, _rigidbody.position + moveVelocity, Color.orange);

            _rigidbody.linearVelocity = gravityVelocity + moveVelocity;
            _rigidbody.rotation = angle;
        }

        private Vector2 GetGravityVelocity(Vector2 velocity, Vector2 gravityAcceleration) {
            var gravityVelocity = (Vector2)Vector3.Project(velocity, gravityAcceleration);
            gravityVelocity += gravityAcceleration * Time.fixedDeltaTime;
            return gravityVelocity;
        }

        private Vector2 GetMovementVelocity(float angle, Vector2 gravityAcceleration) {
            var moveVector = _movement.GetMoveVector();
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Debug.Log($"Rotation: {rotation.eulerAngles.z}, moveVector: {moveVector}, gravityAcceleration: {gravityAcceleration}");
            return (Vector2)(rotation * moveVector);
        }
    }
}
