using System;
using System.Collections.Generic;
using Block.ScriptableObjects;
using UnityEngine;

namespace Level.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Arkanoid/Level/Data")]
    public class LevelData : ScriptableObject
    {
        public List<BlockObjectData> Blocks = new List<BlockObjectData>();
    }

    [Serializable]
    public class BlockObjectData
    {
        public Vector2 Position;
        public BlockData Data;
    }
}