using System.Collections.Generic;
using GravityPlatformer2D.Gameplay.Gravity.Sources;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.Gravity.Receivers {
    public class GravityReceiver : MonoBehaviour, IGravityReceiver {
        [SerializeField] private Transform _gravityCenter;
        
        private HashSet<BaseGravitySource> _gravitySources = new();

        public void AddGravitySource(BaseGravitySource gravitySource) {
            _gravitySources.Add(gravitySource);
        }
        
        public void RemoveGravitySource(BaseGravitySource gravitySource) {
            _gravitySources.Remove(gravitySource);
        }

        public Vector2 GetGravityAcceleration() {
            var gravityAcceleration = Vector2.zero;
            foreach (var gravitySource in _gravitySources) {
                gravityAcceleration += gravitySource.GetGravityAcceleration(_gravityCenter.position);
            }
            return gravityAcceleration;
        }
    }
}
