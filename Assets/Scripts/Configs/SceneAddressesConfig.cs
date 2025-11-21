using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GravityPlatformer2D.Configs {
    [CreateAssetMenu(fileName = "ScenesAddressesConfig", menuName = "Configs/Scenes Addresses")]
    public class SceneAddressesConfig : ScriptableObject {
        [field: SerializeField] public AssetReference GameplayScene { get; private set; }
    }
}
