using System;
using Ball.MonoBehaviours;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace DeathZone.MonoBehaviours
{
    public class DeathZone : MonoBehaviour
    {
        [Inject] private RestartGameScenario _restartGameScenario;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent(out BallView ball))
                return;
            
            _restartGameScenario.Restart();
        }
    }
}