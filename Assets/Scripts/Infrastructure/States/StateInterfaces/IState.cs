namespace Assets.Scripts.Infrastructure.States.StateInterfaces
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}
