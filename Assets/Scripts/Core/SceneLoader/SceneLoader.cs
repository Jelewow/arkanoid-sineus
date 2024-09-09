using System;
using System.Collections;
using Jelewow.Arkanoid.SceneManagement;
using UnityEngine.SceneManagement;

namespace Jelewow.Arkanoid
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly LoadingScreen _loadingScreen;

        public SceneLoader(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen)
        {
            _coroutineRunner = coroutineRunner;
            _loadingScreen = loadingScreen;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (asyncOperation is { isDone: false })
            {
                _loadingScreen.UpdateProgress(asyncOperation.progress);
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
}