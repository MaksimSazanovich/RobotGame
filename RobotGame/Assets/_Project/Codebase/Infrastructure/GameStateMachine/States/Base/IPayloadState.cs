namespace States
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload args);
    }
}