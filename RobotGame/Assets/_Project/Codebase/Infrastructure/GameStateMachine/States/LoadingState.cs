using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class LoadingState : IStateWithArgs<string>
    {
        private GameStateMachine gameStateMachine;
        private ISceneLoader sceneLoader;
        private string sceneName;

        public LoadingState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
            sceneLoader = Game.ProjectContainer.Resolve<ISceneLoader>();
        }

        public void Enter(string sceneName)
        {
            Debug.Log("Enter LoadingState");
            this.sceneName = sceneName;
            
            //ShowCurtain();
            
            sceneLoader.LoadScene(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            switch(sceneName)
            {
                case Scenes.MAIN_MENU: gameStateMachine.Enter<MainMenuBootState>(); break;
            }
        }

        public void Exit()
        {
            Debug.Log("Exit LoadingState");
            //HideCurtain();
        }
    }
}