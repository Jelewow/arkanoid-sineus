using UnityEngine;

namespace Borders
{
    public class Border : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public float Size => Mathf.Sign(transform.position.x) * (Mathf.Abs(transform.position.x) - _spriteRenderer.size.x / 2f);
    }
}