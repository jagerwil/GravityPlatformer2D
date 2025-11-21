using System;
using UnityEngine;

namespace GravityPlatformer2D.Configs {
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject {
        [field: SerializeField] public CharacterMovementInfo Movement { get; private set; }
    }

    [Serializable]
    public class CharacterMovementInfo {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
    }
}
