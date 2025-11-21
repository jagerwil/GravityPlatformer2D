using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GravityPlatformer2D.Configs;
using UnityEngine;
using Zenject;

namespace GravityPlatformer2D.Gameplay.Characters {
    public class GroundChecker : MonoBehaviour {
        private HashSet<Collider2D> _colliders = new();

        private GamePhysicsConfig _physicsConfig;
        private bool _hasCollisions;
        private bool _shouldIgnoreCollisions;

        [Inject]
        private void Inject(GameConfig gameConfig) {
            _physicsConfig = gameConfig.Physics;
        }

        public bool IsColliding { get; private set; }
        
        private void OnTriggerEnter2D(Collider2D other) {
            _colliders.Add(other);
            RefreshIsCollidingValue();
        }

        private void OnTriggerExit2D(Collider2D other) {
            _colliders.Remove(other);
            RefreshIsCollidingValue();
        }

        public void IgnoreCollisionsTemporarily() {
            IgnoreCollisionsTempAsync().Forget();
        }

        private async UniTask IgnoreCollisionsTempAsync() {
            SetIgnoreCollisions(true);
            await UniTask.WaitForSeconds(_physicsConfig.GroundCheckerDisableInterval, cancellationToken: destroyCancellationToken);
            SetIgnoreCollisions(false);
        }

        private void SetIgnoreCollisions(bool shouldIgnoreCollisions) {
            _shouldIgnoreCollisions = shouldIgnoreCollisions;
            RefreshIsCollidingValue();
        }

        private void RefreshIsCollidingValue() {
            IsColliding = !_shouldIgnoreCollisions && _colliders.Count > 0;
        }
    }
}
