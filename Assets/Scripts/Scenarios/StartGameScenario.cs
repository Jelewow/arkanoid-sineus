using Ball;
using Zenject;

namespace DefaultNamespace
{
    public class StartGameScenario : IInitializable
    {
        [Inject] private BallSpawnerService _ballSpawnerService;
        
        public void Initialize()
        {
            _ballSpawnerService.Spawn();
        }
    }
}