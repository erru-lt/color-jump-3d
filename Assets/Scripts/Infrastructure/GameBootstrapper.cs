using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour 
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake() => 
            _gameStateMachine.Enter<LoadProgressState>();

    }
}
