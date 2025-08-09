using Core;
using Services.SceneLoader;
using UnityEngine;

namespace States
{
    public class BootstrapState : IState
    {
        private GameStateMachine gameStateMachine;
        private ISceneLoader sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
            sceneLoader = Game.ProjectContainer.Resolve<ISceneLoader>();
        }
        public void Enter()
        {
            Debug.Log("Enter BootstrapState");
            sceneLoader.LoadScene(Scenes.BOOT, OnLoaded);
        }

        private void OnLoaded()
        {
            gameStateMachine.Enter<LoadingState, string>(Scenes.MAIN_MENU);
        }

        public void Exit()
        {
            Debug.Log("Exit BootstrapState");
        }
    }
}