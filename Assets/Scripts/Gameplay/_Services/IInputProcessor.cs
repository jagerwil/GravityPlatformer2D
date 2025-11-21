using System;
using R3;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay._Services {
    public interface IInputProcessor {
        public ReadOnlyReactiveProperty<float> MoveAxis { get; }
        public event Action onJumpButtonPressed;

        public void Enable();
        public void Disable();
    }
}
