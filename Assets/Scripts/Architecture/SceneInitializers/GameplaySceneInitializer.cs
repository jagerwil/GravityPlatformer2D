using System;
using GravityPlatformer2D.Gameplay.GameStates;
using Jagerwil.Core.Architecture.StateMachine;
using Zenject;

namespace GravityPlatformer2D.Architecture.SceneInitializers {
    public class GameplaySceneInitializer : IInitializable, IDisposable {
        private readonly IGameStateMachine _stateMachine;

        public GameplaySceneInitializer(IGameStateMachine gameStateMachine,
            GameplayMainState mainState) {
            _stateMachine = gameStateMachine;
            _stateMachine.Register(mainState);
        }
        
        public void Initialize() {
            _stateMachine.Enter<GameplayMainState>();
        }

        public void Dispose() {
            _stateMachine?.Unregister<GameplayMainState>();
        }
    }
}
