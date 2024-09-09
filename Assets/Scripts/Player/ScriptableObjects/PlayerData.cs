using UnityEngine;

namespace Player.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Arkanoid/Player/Data")]
    public class PlayerData : ScriptableObject
    {
        [field : SerializeField]
        public float Speed { get; private set; }
        
        [field : SerializeField]
        public int Health { get; private set; }
    }
}