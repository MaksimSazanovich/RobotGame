using UnityEngine;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class CommandFactory : MonoBehaviour
    {
        private PlayerMover playerMover;
        private PlayerWaiter playerWaiter;
        private PlayerRotator playerRotator;
        private PlayerShooter playerShooter;


        private Command singleMoveCommand;
        private Command doubleMoveCommand;
        private Command waitCommand;
        private Command rightRotateCommand;
        private Command leftRotateCommand;
        private Command shootCommand;

        [Inject]
        private void Constructor(PlayerMover playerMover, PlayerWaiter playerWaiter, PlayerRotator playerRotator,
            PlayerShooter playerShooter)
        {
            this.playerShooter = playerShooter;
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
        
        public Command CreateShootCommand()
        {
            if (shootCommand == null)
                return new ShootCommand(playerShooter);
            return shootCommand;
        }
    }
}