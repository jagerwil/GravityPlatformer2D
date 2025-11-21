using GravityPlatformer2D.Configs;
using UnityEngine;
using Zenject;

namespace GravityPlatformer2D.Architecture.Installers {
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Configs/Configs Installer", order = 0)]
    public class ConfigsInstaller : ScriptableObjectInstaller {
        [SerializeField] private SceneAddressesConfig _scenesAddresses;
        
        public override void InstallBindings() {
            Container.Bind<SceneAddressesConfig>().FromInstance(_scenesAddresses).AsSingle();
        }
    }
}
