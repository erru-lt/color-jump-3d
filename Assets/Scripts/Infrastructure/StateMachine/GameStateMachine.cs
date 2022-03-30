using Assets.Scripts.Infrastructure.States;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(LoadProgressState)] = new LoadProgressState(),
                [typeof(LoadLevelState)] = new LoadLevelState()
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();

            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;
    }
}
