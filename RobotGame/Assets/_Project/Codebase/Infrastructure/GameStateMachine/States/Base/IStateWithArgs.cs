namespace Unity_one_love.RobotGame
{
    public interface IStateWithArgs<TArgs> : IExitableState
    {
        void Enter(TArgs args);
    }
}