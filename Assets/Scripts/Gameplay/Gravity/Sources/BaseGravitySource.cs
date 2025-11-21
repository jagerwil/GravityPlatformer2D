using GravityPlatformer2D.Gameplay.Gravity.Receivers;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.Gravity.Sources {
    public abstract class BaseGravitySource : MonoBehaviour {
        protected virtual void OnTriggerEnter2D(Collider2D other) {
            var gravityReceiver = other.GetComponent<IGravityReceiver>();
            if (gravityReceiver != null) {
                gravityReceiver.AddGravitySource(this);
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D other) {
            var gravityReceiver = other.GetComponent<IGravityReceiver>();
            if (gravityReceiver != null) {
                gravityReceiver.RemoveGravitySource(this);
            }
        }
        
        public abstract Vector2 GetGravityAcceleration(Vector3 position);
    }
}
