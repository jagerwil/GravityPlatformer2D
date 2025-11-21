using GravityPlatformer2D.Configs;
using UnityEngine;
using Zenject;

namespace GravityPlatformer2D.Gameplay.Characters.Player {
    public class PlayerView : MonoBehaviour {
        [SerializeField] private CharacterMovement _movement;

        [Inject]
        private void Inject(PlayerConfig config) {
            _movement.SetConfig(config.Movement);
        }
    }
}
