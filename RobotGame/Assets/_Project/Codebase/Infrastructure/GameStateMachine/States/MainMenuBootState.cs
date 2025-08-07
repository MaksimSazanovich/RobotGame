using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class MainMenuBootState : IState
    {
        private GameStateMachine gameStateMachine;

        public MainMenuBootState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Main Menu Boot State Enter");
        }

        public void Exit()
        {
        }
    }
}