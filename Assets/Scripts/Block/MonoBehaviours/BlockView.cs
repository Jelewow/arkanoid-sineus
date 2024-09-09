using System;
using Ball.MonoBehaviours;
using Block.Managers;
using Block.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Block.MonoBehaviours
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        [SerializeReference] private int _currentHp;
        [SerializeReference] private BlockDestroyManager _blockDestroyManager;
        
        [field: SerializeField]
        public BlockData BlockData { get; private set; }

        public void Init(BlockData data, BlockDestroyManager blockDestroyManager)
        {
            _blockDestroyManager = blockDestroyManager;
            BlockData = data;
            _currentHp = data.Health;
            _spriteRenderer.sprite = data.Sprites[0];
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out BallView ball))
                return;

            if (_currentHp - 1 == 0)
            {
                Disable();
                return;
            }

            _currentHp--;
            _spriteRenderer.sprite = BlockData.Sprites[BlockData.Health - _currentHp];
        }

        private void Disable()
        {
            _blockDestroyManager.Add(BlockData.Points, this);
            gameObject.SetActive(false);
        }
    }
}