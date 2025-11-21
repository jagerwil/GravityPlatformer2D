using GravityPlatformer2D.Architecture.SceneInitializers;
using GravityPlatformer2D.Gameplay._Services;
using GravityPlatformer2D.Gameplay._Services.Implementations;
using GravityPlatformer2D.Gameplay._Services.Implementations.InputProcessors;
using Zenject;

namespace GravityPlatformer2D.Architecture.Installers.Scenes {
    public class GameplaySceneInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindServices();
            BindInitializer();
        }

        private void BindServices() {
            var inputActionsProcessor = new InputActionsProcessor();
            var touchButtonsProcessor = new TouchButtonsInputProcessor();
            Container.Bind<IInputService>().To<InputService>()
                     .AsSingle().WithArguments(inputActionsProcessor, touchButtonsProcessor);
        }

        private void BindInitializer() {
            Container.BindInterfacesTo<GameplaySceneInitializer>().AsSingle();
        }
    }
}
