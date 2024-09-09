using Ball.MonoBehaviours;
using UnityEngine;
using Zenject;

namespace Ball
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private BallView _ballView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BallMoveService>().AsSingle().NonLazy();

            Container.Bind<BallSpawnerService>().AsSingle().NonLazy();
            
            Container.BindInstance(_ballView).AsSingle().NonLazy();
        }
    }
}