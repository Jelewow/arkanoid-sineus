using System;
using System.Collections.Generic;
using System.Linq;
using Ball.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace Ball
{
    public class BallSpawnerService
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private BallView _ballViewPrefab;

        public List<BallView> Balls { get; private set; } = new List<BallView>();

        public BallView GetFirstActiveBall()
        {
            var activeBall = Balls.FirstOrDefault(ball => ball.gameObject.activeSelf);
            return !activeBall ? Spawn() : activeBall;
        }
        
        public BallView Spawn()
        {
            var ball = _diContainer.InstantiatePrefabForComponent<BallView>(_ballViewPrefab);
            Balls.Add(ball);
            return ball;
        }
    }
}