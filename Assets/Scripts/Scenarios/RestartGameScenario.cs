using Ball;
using Ball.MonoBehaviours;
using Jelewow.Arkanoid.Game;
using Player;
using Player.Services;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class RestartGameScenario
    {
        [Inject] private BallSpawnerService _ballSpawnerService;
        [Inject] private PlayerView _player;
        [Inject] private BallLineDirection _ballLineDirection;
        [Inject] private SelectBallDirectionScenario _selectBallDirectionScenario;
        [Inject] private PlayerMoveService _playerMoveService;
        [Inject] private PlayerHealthService _playerHealthService;

        public void Restart()
        {
            var ball = _ballSpawnerService.Balls[0];
            ball.StopMove();
            _playerMoveService.StopMove();
            ball.transform.position = new Vector2(0f, -3.6f);
            _player.transform.position = new Vector2(0f, -4f);
            _ballLineDirection.gameObject.SetActive(true);
            _selectBallDirectionScenario.Restart();
            _playerHealthService.TakeDamage();
        }
    }
}