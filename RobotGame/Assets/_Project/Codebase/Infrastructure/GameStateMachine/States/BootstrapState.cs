using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class BootstrapState : IState
    {
        private GameStateMachine gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            Debug.Log("Enter BootstrapState");
            gameStateMachine.Enter<LoadingState, IState>(gameStateMachine.States[typeof(MainMenuBootState)] as IState);
        }

        public void Exit()
        {
            Debug.Log("Exit BootstrapState");
        }
    }
}