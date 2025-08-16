using System;

namespace UnityOneLove.Services.SceneLoader
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onLoaded = null);
    }
}