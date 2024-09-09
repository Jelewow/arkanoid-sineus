using System;
using Jelewow.Arkanoid.Game;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInputService : ITickable
    {
        [Inject] private Camera _camera;
        [Inject] private DiContainer _diContainer;
        
        public Vector2 MousePosition { get; private set; }

        public event Action Clicked;

        public void Tick()
        {
            MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (!Input.GetMouseButtonDown(0)) 
                return;
            
            Clicked?.Invoke();
        }
    }
}