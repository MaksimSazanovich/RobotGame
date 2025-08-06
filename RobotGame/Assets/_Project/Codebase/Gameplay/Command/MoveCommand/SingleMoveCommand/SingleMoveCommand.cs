namespace Unity_one_love.RobotGame
{
    public class SingleMoveCommand : MoveCommand
    {
        public SingleMoveCommand(PlayerMover playerMover)
        {
            this.playerMover = playerMover;
        }
        
        public override void Execute()
        {
            var dir = GetVectorDirection();
            playerMover.Move(dir.x, dir.y);
        }

        public override bool CanBeExecuted() => true;
    }
}