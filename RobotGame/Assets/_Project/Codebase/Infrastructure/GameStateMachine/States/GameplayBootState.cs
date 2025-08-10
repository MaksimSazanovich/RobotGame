using Core;
using DI;
using MainMenu;
using Services.Curtain;
using UnityEngine;

namespace States
{
    public class GamePlayBootState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly DIContainer projectContainer;

        public GamePlayBootState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
            projectContainer = Game.ProjectContainer;
        }
        
        public void Enter()
        {
            //Object.FindAnyObjectByType<Bootstrapper>().Init();
        }

        public void Exit()
        {
            projectContainer.Resolve<ICurtainService>().Hide();
        }
    }
}