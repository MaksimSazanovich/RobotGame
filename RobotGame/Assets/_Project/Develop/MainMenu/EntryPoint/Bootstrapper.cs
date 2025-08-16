using UnityOneLove.Core;
using UnityOneLove.DI;
using UnityOneLove.Services.CompositeDisposable;
using UnityOneLove.States;
using UnityEngine;

namespace UnityOneLove.MainMenu
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MainMenuUIContainer mainMenuUIContainer;
        
        public DIContainer SceneContainer => sceneContainer;
        private DIContainer sceneContainer = new DIContainer(Game.ProjectContainer);

        public void Init()
        {
            Debug.Log("Main Menu Boot State Enter");

            sceneContainer.RegisterInstance(mainMenuUIContainer);
            sceneContainer.RegisterSingleton(() => new MainMenuUIController(sceneContainer));
            SetUpCompositeDisposable();

            sceneContainer.Resolve<GameStateMachine>().Enter<MainMenuState>();
        }

        private void SetUpCompositeDisposable()
        {
            sceneContainer.RegisterSingleton(() => new CompositeDisposable(), Tags.MAIN_MENU_COMPOSITE_DISPOSABLE);
            sceneContainer.Resolve<CompositeDisposable>().Register(sceneContainer.Resolve<MainMenuUIController>());
        }
    }
}