using UnityOneLove.DI;
using UnityOneLove.Services.CompositeDisposable;
using UnityEngine;

namespace UnityOneLove.Core
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