using System;
using System.Collections;
using Core;
using DI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly DIContainer projectContainer;
        private readonly CoroutineRunner coroutineRunner;

        public SceneLoader()
        {
            projectContainer = Game.ProjectContainer;
            coroutineRunner = projectContainer.Resolve<CoroutineRunner>();
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