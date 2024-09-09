using Ball;
using Jelewow.Arkanoid.Game.UI;
using Player;
using Player.ScriptableObjects;
using Player.Services;
using UnityEngine;
using Zenject;

namespace Jelewow.Arkanoid.Game
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Borders _borders;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private BallLineDirection _ballLineDirection;

        [SerializeField] private PlayerData _playerData;

        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private DeathScreen _deathScreen;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMoveService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerHealthService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerScoreService>().AsSingle().NonLazy();

            Container.BindInstance(_playerData).AsSingle().NonLazy();

            Container.BindInstance(_borders).AsSingle().NonLazy();
            Container.BindInstance(_playerView).AsSingle().NonLazy();
            Container.BindInstance(_camera).AsSingle().NonLazy();
            Container.BindInstance(_ballLineDirection).AsSingle().NonLazy();

            Container.BindInstance(_playerHealth).AsSingle().NonLazy();
            Container.BindInstance(_playerScore).AsSingle().NonLazy();
            Container.BindInstance(_deathScreen).AsSingle().NonLazy();
        }
    }
}