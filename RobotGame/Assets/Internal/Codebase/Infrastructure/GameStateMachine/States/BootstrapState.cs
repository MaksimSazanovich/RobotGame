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
            
        }

        public void Exit()
        {
            
        }
    }
}