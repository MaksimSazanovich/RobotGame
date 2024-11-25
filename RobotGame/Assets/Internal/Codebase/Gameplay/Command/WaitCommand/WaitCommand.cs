namespace Unity_one_love.RobotGame
{
    public class WaitCommand : Command
    {
        private PlayerWaiter playerWaiter;
        
        public WaitCommand(PlayerWaiter playerWaiter)
        {
            this.playerWaiter = playerWaiter;
        }

        public override void Execute()
        {
            playerWaiter.Wait();
        }

        public override bool CanBeExecuted() => true;

        public override PlayerCommander GetPlayerCommander() => playerWaiter;
    }
}