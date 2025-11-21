using System.Collections.Generic;
using GravityPlatformer2D.Architecture.SceneInitializers;
using GravityPlatformer2D.Gameplay._Services;
using GravityPlatformer2D.Gameplay._Services.Implementations;
using GravityPlatformer2D.Gameplay._Services.Implementations.InputProcessors;
using GravityPlatformer2D.Gameplay.GameStates;
using Zenject;

namespace GravityPlatformer2D.Architecture.Installers.Scenes {
    public class GameplaySceneInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindServices();
            BindGameStates();
            BindInitializer();
        }

        private void BindServices() {
            List<IInputProcessor> processors = new() {
                new InputActionsProcessor(),
                new TouchButtonsInputProcessor(),
            };
            Container.Bind<IInputService>().To<InputService>()
                     .AsSingle().WithArguments(processors);
        }

        private void BindGameStates() {
            Container.Bind<GameplayMainState>().AsSingle();
        }

        private void BindInitializer() {
            Container.BindInterfacesTo<GameplaySceneInitializer>().AsSingle();
        }
    }
}
