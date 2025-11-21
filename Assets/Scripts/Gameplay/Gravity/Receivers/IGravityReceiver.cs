using GravityPlatformer2D.Gameplay.Gravity.Sources;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.Gravity.Receivers {
    public interface IGravityReceiver {
        public void AddGravitySource(BaseGravitySource gravitySource);
        public void RemoveGravitySource(BaseGravitySource gravitySource);
        public Vector2 GetGravityAcceleration();
    }
}
