using Ball.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace Ball
{
    public class BallMoveService : ITickable
    {
        [Inject] private BallView _ballView;
        
        public void Tick()
        {
            //_ballView.Rigidbody2D.velocity = new Vector2(5f, 5f) * _ballView.Direction;
        }
    }
}