using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Infrastructure.States.StateInterfaces;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}