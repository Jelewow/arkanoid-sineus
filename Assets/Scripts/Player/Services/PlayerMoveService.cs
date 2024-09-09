using Player;
using Player.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Jelewow.Arkanoid.Game
{
    public class PlayerMoveService : IFixedTickable
    {
        [Inject] private PlayerView _playerView;
        [Inject] private Borders _borders;
        [Inject] private PlayerData _playerData;
        [Inject] private PlayerInputService _inputService;

        private bool _canMove;
        
        public void StartMove()
        {
            _canMove = true;
        }

        public void StopMove()
        {
            _canMove = false;
        }
        
        public void FixedTick()
        {
            if (!_canMove)
                return;
            
            var direction = new Vector2(_inputService.MousePosition.x, -4f);
            
            var nextPosition =
                Vector2.MoveTowards(_playerView.Rigidbody2D.position, direction,
                    _playerData.Speed * Time.fixedDeltaTime);
            var clampedPositionX =
                Mathf.Clamp(nextPosition.x, _borders.LeftBorder.Size + _playerView.Width,
                    _borders.RightBorder.Size - _playerView.Width);
            var endPosition
                = new Vector2(clampedPositionX, nextPosition.y);
            _playerView.Rigidbody2D.MovePosition(endPosition);
        }
    }
}