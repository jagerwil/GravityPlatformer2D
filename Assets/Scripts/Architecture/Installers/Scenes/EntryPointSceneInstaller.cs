using GravityPlatformer2D.Architecture.SceneInitializers;
using Zenject;

namespace GravityPlatformer2D.Architecture.Installers.Scenes {
    public class EntryPointSceneInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.BindInterfacesTo<EntryPointSceneInitializer>().AsSingle();
        }
    }
}
