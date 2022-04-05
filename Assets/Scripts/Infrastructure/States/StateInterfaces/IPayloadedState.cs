namespace Assets.Scripts.Infrastructure.States.StateInterfaces
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}
