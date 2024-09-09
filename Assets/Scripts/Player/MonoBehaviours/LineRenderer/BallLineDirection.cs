using System;
using Player;
using UnityEngine;
using Zenject;

namespace Ball
{
    public class BallLineDirection : MonoBehaviour
    {
        [Inject] private PlayerInputService _inputService;
        
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Transform _player;
        
        private void Update()
        {
            var startPoint = _player.position;
            var endPoint = _inputService.MousePosition;

            _lineRenderer.SetPosition(0, startPoint);
            _lineRenderer.SetPosition(1, endPoint);
        }
    }
}