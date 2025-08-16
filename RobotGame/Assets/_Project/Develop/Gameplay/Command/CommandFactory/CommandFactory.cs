using Zenject;

namespace Unity_one_love.RobotGame
{
    public class CommandFactory 
    {
        private PlayerMover playerMover;
        private PlayerWaiter playerWaiter;
        private PlayerRotator playerRotator;

        private Command singleMoveCommand;
        private Command doubleMoveCommand;
        private Command waitCommand;
        private Command rightRotateCommand;
        private Command leftRotateCommand;

        [Inject]
        private void Constructor(PlayerMover playerMover, PlayerWaiter playerWaiter, PlayerRotator playerRotator)
        {
            this.playerRotator = playerRotator;
            this.playerMover = playerMover;
            this.playerWaiter = playerWaiter;
        }

        public Command CreateSingleMoveCommand()
        {
            if (singleMoveCommand == null)
                return new SingleMoveCommand(playerMover);
            return singleMoveCommand;
        }

        public Command CreateDoubleMoveCommand()
        {
            if (doubleMoveCommand == null)
                return new DoubleMoveCommand(playerMover);
            return doubleMoveCommand;
        }

        public Command CreateWaitCommand()
        {
            if (waitCommand == null)
                return new WaitCommand(playerWaiter);
            return waitCommand;
        }

        public Command CreateRightRotateCommand()
        {
            if (rightRotateCommand == null)
                return new RotateCommand(playerRotator, RotationDirection.Right);
            return rightRotateCommand;
        }

        public Command CreateLeftRotateCommand()
        {
            if (leftRotateCommand == null)
                return new RotateCommand(playerRotator, RotationDirection.Left);
            return leftRotateCommand;
        }  
    }
}