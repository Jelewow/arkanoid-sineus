using System;
using System.Collections.Generic;
using Block.MonoBehaviours;
using UnityEngine;

namespace Block.ScriptableObjects
{
    [Serializable]
    [CreateAssetMenu(menuName = "Arkanoid/Block/Data")]
    public class BlockData : ScriptableObject
    {
        public List<Sprite> Sprites;

        public int Health => Sprites.Count;
        public int Points => Sprites.Count;
    }
}