using TMPro;
using UnityEngine;

namespace Jelewow.Arkanoid.Game.UI
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;

        public void AddScore(int points)
        {
            _score.text = (int.Parse(_score.text) + points).ToString();
        }
    }
}