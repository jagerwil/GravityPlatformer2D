using System;
using UnityEngine;

namespace GravityPlatformer2D.Configs {
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/Game")]
    public class GameConfig : ScriptableObject {
        [field: SerializeField] public GamePhysicsConfig Physics { get; private set; }
        
    }

    [Serializable]
    public class GamePhysicsConfig {
        [field: SerializeField] public float GroundCheckerDisableInterval { get; private set; } = 0.2f;
    }
}
