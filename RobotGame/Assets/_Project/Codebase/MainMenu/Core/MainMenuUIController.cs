using System;
using DI;
using Services.SceneLoader;
using States;
using UnityEngine;

namespace MainMenu
{
    public class MainMenuUIController : IDisposable
    {
        private readonly DIContainer sceneContainer;
        private readonly MainMenuUIContainer mainMenuUIContainer;

        public MainMenuUIController(DIContainer sceneContainer)
        {
            Debug.Log("fefwefwf");
            this.sceneContainer = sceneContainer;
            mainMenuUIContainer = sceneContainer.Resolve<MainMenuUIContainer>();
            
            Debug.Log(mainMenuUIContainer);
            mainMenuUIContainer.PlayGameButton.onClick.AddListener(LoadGameplayScene);
        }

        public void Dispose()
        {
            mainMenuUIContainer.PlayGameButton.onClick.RemoveListener(LoadGameplayScene);
        }

        private void LoadGameplayScene()
        {
            Debug.Log("meow");
            sceneContainer.Resolve<GameStateMachine>().Enter<LoadingState, string>(Scenes.CORE);
        }
    }
}