using System;
using Ball;
using Ball.MonoBehaviours;
using Jelewow.Arkanoid.Game;
using Player;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class SelectBallDirectionScenario : IDisposable
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private PlayerMoveService _moveService;
        [Inject] private BallLineDirection _ballLineDirection;
        [Inject] private BallSpawnerService _ballSpawnerService;
        
        private readonly PlayerInputService _inputService;

        [Inject]
        public SelectBallDirectionScenario(PlayerInputService playerInputService)
        {
            _inputService = playerInputService;
            _inputService.Clicked += OnClicked;
        }
        
        private void OnClicked()
        {
            _ballLineDirection.gameObject.SetActive(false);

            var ball = _ballSpawnerService.GetFirstActiveBall();
            ball.StartMove(_inputService.MousePosition);
            
            _moveService.StartMove();
            Dispose();
        }

        public void Restart()
        {
            _inputService.Clicked += OnClicked;
        }
        
        public void Dispose()
        {
            _inputService.Clicked -= OnClicked;
        }
    }
}