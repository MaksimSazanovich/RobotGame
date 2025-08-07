using System;

namespace Unity_one_love.RobotGame
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onLoaded = null);
    }
}