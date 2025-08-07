using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity_one_love.RobotGame
{
    public class SceneLoader : ISceneLoader
    {
        private CoroutineRunner coroutineRunner;

        public SceneLoader(CoroutineRunner coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
        }
        
        public void LoadScene(string sceneName, Action onLoaded = null)
        {
            coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneName, onLoaded));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}