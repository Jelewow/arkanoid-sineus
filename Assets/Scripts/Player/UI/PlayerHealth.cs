using TMPro;
using UnityEngine;

namespace Jelewow.Arkanoid.Game.UI
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthScore;

        public void UpdateHealth(int health)
        {
            _healthScore.text = health.ToString();
        }
    }
}