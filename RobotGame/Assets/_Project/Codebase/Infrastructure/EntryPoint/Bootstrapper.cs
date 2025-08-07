using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class Bootstrapper
    {
        private static Bootstrapper instance;

        private DIContainer projectContainer = Game.ProjectContainer;
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
            projectContainer.RegisterSingleton(SetUpCoroutineRunner);
            projectContainer.RegisterInterface<SceneLoader, ISceneLoader>(
                () => new SceneLoader(projectContainer.Resolve<CoroutineRunner>()));
            
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

        private CoroutineRunner SetUpCoroutineRunner()
        {
            var coroutineRunner = new GameObject("CoroutineRunner").AddComponent<CoroutineRunner>();
            Object.DontDestroyOnLoad(coroutineRunner.gameObject);
            
            return coroutineRunner;
        }

        private void EnterBootstrapState()
        {
            gameStateMachine = projectContainer.Resolve<GameStateMachine>();
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}