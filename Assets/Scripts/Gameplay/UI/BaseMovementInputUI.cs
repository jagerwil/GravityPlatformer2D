using R3;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.UI {
    public abstract class BaseMovementInputUI : MonoBehaviour {
        public abstract ReadOnlyReactiveProperty<float> InputAxis { get; }
    }
}
