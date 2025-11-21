using GravityPlatformer2D.Gameplay._Services;
using Jagerwil.Core.Architecture.StateMachine;
using UnityEngine;

namespace GravityPlatformer2D.Gameplay.GameStates {
    public class GameplayMainState : IGameState {
        private readonly IInputService _inputService;

        public GameplayMainState(IInputService inputService) {
            _inputService = inputService;
        }
        
        public void Enter() {
            _inputService.Enable();
        }
        
        public void Exit() {
            _inputService.Disable();
        }
    }
}
