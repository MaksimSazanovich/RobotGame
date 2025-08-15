using UnityOneLove.DI;
using UnityOneLove.MainMenu;
using UnityOneLove.Services.CompositeDisposable;
using UnityEngine;

namespace UnityOneLove.States
{
    public class MainMenuState : IState
    {
        private readonly GameStateMachine stateMachine;
        
        public MainMenuState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void Enter()
        {
            Debug.Log("MainMenuState: Enter");
        }

        public void Exit()
        {
            Object.FindAnyObjectByType<Bootstrapper>().SceneContainer.
                Resolve<CompositeDisposable>(Tags.MAIN_MENU_COMPOSITE_DISPOSABLE).Dispose();
        }
    }
}