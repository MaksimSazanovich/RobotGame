namespace Unity_one_love.RobotGame
{
    public abstract class Command
    {
        public abstract void Execute();
        
        public abstract bool CanBeExecuted();

        public abstract PlayerCommander GetPlayerCommander();
    }
}