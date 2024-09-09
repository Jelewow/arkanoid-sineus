using System.Collections;
using Jelewow.Arkanoid;
using Jelewow.Arkanoid.SceneManagement;
using UnityEngine;
using Zenject;

namespace Core.Bootstrap
{
    public class BootstrapService : IInitializable
    {
        [Inject] private LoadingScreen _loadingScreen;
        [Inject] private ICoroutineRunner _coroutineRunner;
        
        public void Initialize()
        {
            SetSystemSettings();
            StartGame();
        }
        
        private void StartGame()
        {
            _coroutineRunner.StartCoroutine(LoadGame());
        }
        
        private void SetSystemSettings()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        
        private IEnumerator LoadGame()
        {
            _loadingScreen.Show();

            var sceneLoader = new SceneLoader(_coroutineRunner, _loadingScreen);
            sceneLoader.Load("Game");

            _loadingScreen.Hide();

            yield return null;
        }
    }
}