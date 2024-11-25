namespace Unity_one_love.RobotGame
{
    public class ShootCommand : Command
    {
        private PlayerShooter playerShooter;

        public ShootCommand(PlayerShooter playerShooter)
        {
            this.playerShooter = playerShooter;
        }
        
        public override void Execute()
        {
            playerShooter.Shoot();
        }

        public override bool CanBeExecuted() => true;

        public override PlayerCommander GetPlayerCommander() => playerShooter;
    }
}