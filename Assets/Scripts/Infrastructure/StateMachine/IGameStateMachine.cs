using Assets.Scripts.Infrastructure.States;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
    }
}