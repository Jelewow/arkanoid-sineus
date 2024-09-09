using System;
using System.Collections.Generic;
using System.Linq;
using Ball;
using Block.MonoBehaviours;
using Jelewow.Arkanoid.Game;
using Jelewow.Arkanoid.Game.UI;
using UnityEngine;
using Zenject;

namespace Block.Managers
{
    public class BlockDestroyManager : MonoBehaviour
    {
        [Inject] private BallSpawnerService _ballSpawnerService;
        [Inject] private PlayerMoveService _moveService;
        
        [SerializeField] private PlayerScore _score;
        [SerializeField] private WinScreen _winScreen;

        private List<BlockView> _blocks = new List<BlockView>();
        
        private void Start()
        {
            _blocks = FindObjectsOfType<BlockView>().ToList();
        }

        public void Add(int points, BlockView blockView)
        {
            _score.AddScore(points);
            Destroy(blockView);
        }

        private void Destroy(BlockView block)
        {
            _blocks.Remove(block);
            if (_blocks.Count == 0)
            {
                _ballSpawnerService.Balls[0].StopMove();
                _moveService.StopMove();
                _winScreen.gameObject.SetActive(true);
            }
        }
    }
}