using System;
using UnityEngine;

namespace GravityPlatformer2D.Configs {
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject {
        [field: SerializeField] public PlayerMovementInfo Movement { get; private set; }
    }

    [Serializable]
    public class PlayerMovementInfo {
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}
