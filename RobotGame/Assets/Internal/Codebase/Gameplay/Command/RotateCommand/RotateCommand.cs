namespace Unity_one_love.RobotGame
{
    public class RotateCommand : Command
    {
        private PlayerRotator playerRotator;
        private RotationDirection rotationDirection;
        
        public RotateCommand(PlayerRotator playerRotator, RotationDirection rotationDirection)
        {
            this.rotationDirection = rotationDirection;
            this.playerRotator = playerRotator;
        }

        public override void Execute()
        {
            playerRotator.Rotate(rotationDirection);
        }

        public override bool CanBeExecuted() => true;

        public override PlayerCommander GetPlayerCommander() => playerRotator;
    }
}