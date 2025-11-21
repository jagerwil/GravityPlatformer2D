using System;
using R3;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay._Services.Implementations.InputProcessors {
    public class TouchButtonsInputProcessor : IInputProcessor {
        private readonly ReactiveProperty<float> _moveAxis = new();
        
        public ReadOnlyReactiveProperty<float> MoveAxis => _moveAxis;
        public event Action onJumpButtonPressed;
        
        public void Enable() {
            
        }
        
        public void Disable() {
            
        }
    }
}
