using GravityPlatformer2D.Architecture._Services;
using Jagerwil.Core.Architecture.StateMachine;
using UnityEngine;

namespace GravityPlatformer2D.Architecture.StateMachine {
    public class SceneLoadingState : IGameState<SceneType> {
        private readonly ISceneLoader _sceneLoader;

        public SceneLoadingState(ISceneLoader sceneLoader) {
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(SceneType sceneType) {
            _sceneLoader.LoadAsync(sceneType);
        }

        public void Exit() { }
    }
}
