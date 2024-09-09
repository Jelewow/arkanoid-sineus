using System.Collections.Generic;
using Block.MonoBehaviours;
using Block.Services;
using Level.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Level.Services
{
    public class SaveLevelService
    {
        public List<BlockObjectData> GetBlocks()
        {
            var blocksObjectData = new List<BlockObjectData>();
            var blocks = Object.FindObjectsOfType<BlockView>();

            foreach (var block in blocks)
            {
                var blockObjectData = new BlockObjectData
                {
                    Position = block.transform.position,
                    Data = block.BlockData,
                };
                
                blocksObjectData.Add(blockObjectData);
            }

            return blocksObjectData;
        }
    }
}