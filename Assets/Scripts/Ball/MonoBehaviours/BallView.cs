using System;
using Player;
using UnityEngine;
using Zenject;

namespace Ball.MonoBehaviours
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector2 _lastVelocity;
        
        private bool _canMove;

        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }

        private void Update()
        {
            if (!_canMove)
                return;

            _lastVelocity = Rigidbody2D.velocity;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_canMove)
                return;

            var inDirection = _lastVelocity.normalized;
            var inNormal = other.GetContact(0).normal;
            var direction = Vector2.Reflect(inDirection, inNormal);
            var newVelocity = direction * _speed;

            if (other.gameObject.TryGetComponent<PlayerView>(out var playerView))
            {
                var relativePosition = transform.position - playerView.transform.position;
                var diff = 1f - Mathf.InverseLerp(-playerView.Width / 2f, playerView.Width / 2f, relativePosition.x);
                var forceAngle = Mathf.LerpAngle(-30f, 30f, diff);
                var vector = Quaternion.Euler(0f, 0f, forceAngle) * Vector2.up;
                newVelocity = _speed * vector;
            }

            Rigidbody2D.velocity = newVelocity;
        }

        public void StartMove(Vector2 direction)
        {
            _canMove = true;
            var vector2Position = (Vector2)transform.position;
            direction -= vector2Position;
            Rigidbody2D.AddForce(direction.normalized * _speed, ForceMode2D.Impulse);
        }

        public void StopMove()
        {
            _canMove = false;
            Rigidbody2D.velocity = Vector2.zero;
        }
    }
}