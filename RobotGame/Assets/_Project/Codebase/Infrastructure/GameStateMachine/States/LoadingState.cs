using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class LoadingState : IStateWithArgs<IState>
    {
        private GameStateMachine gameStateMachine;

        public LoadingState(GameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }

        public void Enter(IState nextState)
        {
            Debug.Log("Enter LoadingState");
            //ShowCurtain();
            //ChangeToEmptyScene();
            switch(nextState)
            {
                case MainMenuBootState: gameStateMachine.Enter<MainMenuBootState>(); break;
            }
            
            //ChangeToNextScene();
        }

        public void Exit()
        {
            Debug.Log("Exit LoadingState");
            //HideCurtain();
        }
    }
}