using GravityPlatformer2D.Architecture.SceneInitializers;
using Zenject;

namespace GravityPlatformer2D.Architecture.Installers.Scenes {
    public class GameplaySceneInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.BindInterfacesTo<GameplaySceneInitializer>().AsSingle();
        }
    }
}
