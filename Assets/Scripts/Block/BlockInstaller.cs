using Block.MonoBehaviours;
using Block.ScriptableObjects;
using Block.Services;
using UnityEngine;
using Zenject;

namespace Block
{
    public class BlockInstaller : MonoInstaller
    {
        [SerializeField] private BlockView _blockPrefab;
        [SerializeField] private BlockDatabase _blockDatabase;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_blockDatabase).AsSingle().NonLazy();

            Container.BindInstance(_blockPrefab).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<BlockSpawnService>().AsSingle().NonLazy();
        }
    }
}