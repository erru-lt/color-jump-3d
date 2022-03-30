namespace Assets.Scripts.Infrastructure.States
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IState : IExitableState
    {
        void Enter();
    }
}
