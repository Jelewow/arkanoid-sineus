using Core.Bootstrap;
using Jelewow.Arkanoid;
using Jelewow.Arkanoid.SceneManagement;
using UnityEngine;
using Zenject;

namespace Core
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private CoroutineRunner _coroutineRunner;
        
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>().FromComponentInNewPrefab(_loadingScreen).AsSingle();
            Container.Bind<ICoroutineRunner>().FromComponentInNewPrefab(_coroutineRunner).AsSingle();
            
            Container.BindInterfacesAndSelfTo<BootstrapService>().AsSingle().NonLazy();
        }
    }
}