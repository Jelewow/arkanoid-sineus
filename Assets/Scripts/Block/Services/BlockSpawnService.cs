using System.Collections.Generic;
using Block.Managers;
using Block.MonoBehaviours;
using Block.ScriptableObjects;
using Level.ScriptableObjects;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Block.Services
{
    public class BlockSpawnService
    {
        public List<BlockView> Blocks = new List<BlockView>();
        
        public List<BlockView> Spawn(LevelData levelData, Transform parent, BlockView prefab,
            BlockDestroyManager blockDestroyManager)
        {
            for (int i = 0; i < levelData.Blocks.Count; i++)
            {
                BlockView block;
#if UNITY_EDITOR
                block = PrefabUtility.InstantiatePrefab(prefab, parent) as BlockView;
#else
                block = Object.Instantiate(prefab, parent) as BlockView;
#endif
                block.Init(levelData.Blocks[i].Data, blockDestroyManager);
                block.transform.position = levelData.Blocks[i].Position;
                Blocks.Add(block);
            }

            return Blocks;
        }
    }
}