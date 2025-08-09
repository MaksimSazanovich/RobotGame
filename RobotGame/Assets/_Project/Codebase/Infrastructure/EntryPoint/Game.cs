using DI;
using Services.Disposables;
using UnityEngine;

namespace Core
{
    public static class Game
    {
        public static DIContainer ProjectContainer = new DIContainer();

        public static void Init()
        {
            Application.quitting += OnApplicationQuit;
        }

        private static void OnApplicationQuit()
        {
            ProjectContainer.Resolve<CompositeDisposable>().Dispose();
            Application.quitting -= OnApplicationQuit;
        }
    }
}