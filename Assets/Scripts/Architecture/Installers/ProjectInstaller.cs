using GravityPlatformer2D.Architecture._Services;
using GravityPlatformer2D.Architecture._Services.Implementations;
using GravityPlatformer2D.Architecture.StateMachine;
using Jagerwil.Core.Architecture.StateMachine;
using Jagerwil.Core.Services;
using Jagerwil.Core.Services.Implementations;
using Zenject;

namespace GravityPlatformer2D.Architecture.Installers {
    public class ProjectInstaller : MonoInstaller {
        public override void InstallBindings() {
            BindServices();
            BindGameStateMachine();
        }

        private void BindServices() {
            Container.Bind<IAddressablesLoader>().To<AddressablesLoader>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindGameStateMachine() {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<InitializationState>().AsSingle();
            Container.Bind<SceneLoadingState>().AsSingle();
        }
    }
}
