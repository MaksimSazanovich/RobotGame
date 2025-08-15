using UnityOneLove.Core;
using UnityOneLove.DI;
using UnityOneLove.MainMenu;
using UnityOneLove.Services.Curtain;
using UnityEngine;

namespace UnityOneLove.States
{
    public class MainMenuBootState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly DIContainer projectContainer;

        public MainMenuBootState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
            projectContainer = Game.ProjectContainer;
        }
        
        public void Enter()
        {
            Object.FindAnyObjectByType<Bootstrapper>().Init();
        }

        public void Exit()
        {
            Debug.Log("Main Menu Boot State Exit");
            projectContainer.Resolve<ICurtainService>().Hide();
        }
    }
}