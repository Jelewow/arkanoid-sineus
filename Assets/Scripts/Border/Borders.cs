using Borders;
using UnityEngine;

namespace Jelewow.Arkanoid.Game
{
    public class Borders : MonoBehaviour
    {
        [field : SerializeField]
        public Border LeftBorder { get; private set; }
        [field : SerializeField]
        public Border RightBorder { get; private set; }
    }
}