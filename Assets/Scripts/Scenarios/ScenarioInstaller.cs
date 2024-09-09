using Zenject;

namespace DefaultNamespace
{
    public class ScenarioInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StartGameScenario>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SelectBallDirectionScenario>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<RestartGameScenario>().AsSingle().NonLazy();
        }
    }
}