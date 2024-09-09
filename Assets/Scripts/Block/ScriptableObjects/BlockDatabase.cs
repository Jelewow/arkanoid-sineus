using System.Collections.Generic;
using UnityEngine;

namespace Block.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Arkanoid/Block/Database")]
    public class BlockDatabase : ScriptableObject
    {
        public List<BlockData> Blocks;

        public BlockData GetRandomBlock()
        {
            return Blocks[Random.Range(0, Blocks.Count)];
        }
    }
}