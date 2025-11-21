using UnityEngine;

namespace GravityPlatformer2D.Gameplay.Gravity.Sources {
    public class RectangleGravitySource : BaseGravitySource {
        [SerializeField] private float _gravityAcceleration = 9.8f;
        [SerializeField] private BoxCollider2D _boxCollider;

        public override Vector2 GetGravityAcceleration(Vector3 position) {
            return GetGravityDirection(position) * _gravityAcceleration;
        }

        private Vector2 GetGravityDirection(Vector3 position) {
            var bounds = _boxCollider.bounds;
            
            //Gravitate towards top / bottom size
            if (position.x >= bounds.min.x && position.x <= bounds.max.x) {
                return position.y < bounds.min.y ? Vector2.up : Vector2.down;
            }
            
            //Gravitate towards left / right side
            if (position.y >= bounds.min.y && position.y <= bounds.max.y) {
                return position.x < bounds.min.x ? Vector2.right : Vector2.left;
            }

            //Gravitate towards a corner (for smooth gravity change)
            var cornerPos = new Vector3 {
                x = position.x < bounds.min.x ? bounds.min.x : bounds.max.x,
                y = position.y < bounds.min.y ? bounds.min.y : bounds.max.y,
                z = 0f,
            };
            var direction = cornerPos - position;
            return direction.normalized;
        }
    }
}
