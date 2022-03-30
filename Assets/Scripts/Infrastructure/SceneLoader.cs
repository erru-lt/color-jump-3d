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
            if(SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
            }

            AsyncOperation waitForNextScene = SceneManager.LoadSceneAsync(sceneName);

            if(waitForNextScene.isDone == false)
            {
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
}
