using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Jelewow.Arkanoid.Game.UI
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(0);
        }
    }
}