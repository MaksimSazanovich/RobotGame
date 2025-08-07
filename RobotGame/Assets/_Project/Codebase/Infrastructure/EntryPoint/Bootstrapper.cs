using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class Bootstrapper
    {
        private static Bootstrapper instance;

        private DIContainer projectContainer = new DIContainer();
        private GameStateMachine gameStateMachine;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void GameEntryPoint()
        {
            instance = new Bootstrapper();
            instance.RunGame();
        }

        private void RunGame()
        {
            projectContainer.RegisterSingleton(SetUpGameStateMachine);
            
            EnterBootstrapState();
        }

        private GameStateMachine SetUpGameStateMachine()
        {
            gameStateMachine = new GameStateMachine();
            
            gameStateMachine.AddState(new BootstrapState(gameStateMachine));
            gameStateMachine.AddState(new LoadingState(gameStateMachine));
            gameStateMachine.AddState(new MainMenuBootState(gameStateMachine));
            
            return gameStateMachine;
        }

        private void EnterBootstrapState()
        {
            gameStateMachine = projectContainer.Resolve<GameStateMachine>();
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}