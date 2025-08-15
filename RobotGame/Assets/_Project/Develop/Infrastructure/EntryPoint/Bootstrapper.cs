using UnityOneLove.AssetMenegement;
using UnityOneLove.Core;
using UnityOneLove.DI;
using UnityOneLove.Infrastructure.Factories;
using UnityOneLove.Services.Curtain;
using UnityOneLove.Services.CompositeDisposable;
using UnityOneLove.Services.Pause;
using UnityOneLove.Services.SceneLoader;
using UnityOneLove.States;
using UnityEngine;

namespace UnityOneLove.EntryPoint
{
    public class Bootstrapper
    {
        private static Bootstrapper instance;

        private readonly DIContainer projectContainer = Game.ProjectContainer;
        private GameStateMachine gameStateMachine;
        
        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void AutoStartGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            
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