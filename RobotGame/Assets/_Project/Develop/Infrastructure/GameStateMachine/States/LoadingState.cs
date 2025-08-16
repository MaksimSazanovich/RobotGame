using UnityOneLove.Core;
using UnityOneLove.DI;
using UnityOneLove.Services.Curtain;
using UnityOneLove.Services.SceneLoader;
using UnityEngine;

namespace UnityOneLove.States
{
    public class LoadingState : IPayloadState<string>
    {
        private readonly DIContainer projectContainer;
        
        private readonly GameStateMachine gameStateMachine;
        private readonly ISceneLoader sceneLoader;
        private readonly ICurtainService curtain;
        
        private string sceneName;

        public LoadingState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
            projectContainer = Game.ProjectContainer;
            
            sceneLoader = projectContainer.Resolve<ISceneLoader>();
            curtain = projectContainer.Resolve<ICurtainService>();
        }

        public void Enter(string sceneName)
        {
            Debug.Log("Enter LoadingState");
            this.sceneName = sceneName;
            
            curtain.Show();
            
            sceneLoader.LoadScene(Scenes.EMPTY, () => sceneLoader.LoadScene(sceneName, OnLoaded));
        }

        private void OnLoaded()
        {
            switch(sceneName)
            {
                case Scenes.MAIN_MENU: gameStateMachine.Enter<MainMenuBootState>(); break;
                case Scenes.CORE: gameStateMachine.Enter<GamePlayBootState>(); break;
            }
        }

        public void Exit()
        {
            Debug.Log("Exit LoadingState");
        }
    }
}