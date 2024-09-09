using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [field: SerializeField]
        public Rigidbody2D Rigidbody2D { get; private set; }

        public float Width => _spriteRenderer.size.x / 2f;
    }
}