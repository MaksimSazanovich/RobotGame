using AssetMenegement;
using Core;
using DI;
using Infrastructure.Factories;
using Services.Curtain;
using Services.CompositeDisposable;
using Services.Pause;
using Services.SceneLoader;
using States;
using UnityEngine;

namespace EntryPoint
{
    public class Bootstrapper
    {
        private static Bootstrapper instance;

        private readonly DIContainer projectContainer = Game.ProjectContainer;
        private GameStateMachine gameStateMachine;
        
        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void GameEntryPoint()
        {
            instance = new Bootstrapper();
            instance.RunGame();
        }

        private void RunGame()
        {
            Game.Init();
            
            projectContainer.RegisterSingleton(SetUpGameStateMachine);
            projectContainer.RegisterSingleton(SetUpCoroutineRunner);
            projectContainer.RegisterInterface<SceneLoader, ISceneLoader>(() => new SceneLoader());
            projectContainer.RegisterInterface<AssetProvider, IAssetProvider>(() => new AssetProvider());
            projectContainer.RegisterInterface<UIFactory, IUIFactory>(() => new UIFactory());
            projectContainer.RegisterInterface<CurtainService, ICurtainService>(() => new CurtainService());
            
            projectContainer.RegisterSingleton(() => new CompositeDisposable());
            
            //TODO: Перенести сервис паузы в бутстраппер геймплея
            projectContainer.RegisterSingleton(() => new PauseRepository());
            projectContainer.RegisterInterface<PauseService, IPauseService>(() =>
                new PauseService());
            
            projectContainer.Resolve<CompositeDisposable>().Register(projectContainer.Resolve<PauseRepository>());
            
            //projectContainer.RegisterInstance(Object.FindAnyObjectByType<MainMenu.Bootstrapper>(), Tags.MAIN_MENU_BOOTSTRAPPER);
            
            EnterBootstrapState();
        }

        private GameStateMachine SetUpGameStateMachine()
        {
            gameStateMachine = new GameStateMachine();
            
            gameStateMachine.AddState(new BootstrapState(gameStateMachine));
            gameStateMachine.AddState(new LoadingState(gameStateMachine));
            gameStateMachine.AddState(new MainMenuBootState(gameStateMachine));
            gameStateMachine.AddState(new MainMenuState(gameStateMachine));
            gameStateMachine.AddState(new GamePlayBootState(gameStateMachine));
            
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