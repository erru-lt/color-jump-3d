using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string sceneName, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            AsyncOperation waitForNextScene = SceneManager.LoadSceneAsync(sceneName);

            while (waitForNextScene.isDone == false)
            {
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
}
