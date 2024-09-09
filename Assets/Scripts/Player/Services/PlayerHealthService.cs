using Ball;
using Ball.MonoBehaviours;
using Jelewow.Arkanoid.Game;
using Jelewow.Arkanoid.Game.UI;
using Player.ScriptableObjects;
using Zenject;

namespace Player.Services
{
    public class PlayerHealthService : IInitializable
    {
        [Inject] private PlayerData _playerData;
        [Inject] private PlayerHealth _playerHealth;
        [Inject] private DeathScreen _deathScreen;
        [Inject] private BallSpawnerService _ballSpawnerService;
        [Inject] private PlayerMoveService _moveService;

        private int _currentHealth;
        
        public void Initialize()
        {
            _currentHealth = _playerData.Health;
        }

        public void TakeDamage()
        {
            _currentHealth--;
            _playerHealth.UpdateHealth(_currentHealth);
            
            if (_currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            _ballSpawnerService.Balls[0].StopMove();
            _moveService.StopMove();
            _deathScreen.gameObject.SetActive(true);
        }
    }
}