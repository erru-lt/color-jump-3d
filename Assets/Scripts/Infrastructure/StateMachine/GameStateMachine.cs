using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Infrastructure.States.StateInterfaces;
using Assets.Scripts.Logic;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.UI.UIFactory;
using System;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        [Inject]
        public GameStateMachine(IGameFactory gameFactory, IStaticDataService staticDataService, IUIFactory uiFactory, SceneLoader sceneLoader, LoadingScreen loadingScreen)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(LoadProgressState)] = new LoadProgressState(this),
                [typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, staticDataService, uiFactory, sceneLoader, loadingScreen),
                [typeof(GameLoopState)] = new GameLoopState(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();

            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();

            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
