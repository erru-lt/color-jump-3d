using Assets.Scripts.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string Level1 = "Level1";
        private IGameStateMachine _gameStateMachine;

        public LoadProgressState(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter()
        {
            LoadProgress();
            _gameStateMachine.Enter<LoadLevelState, string>(Level1);
        }

        private void LoadProgress() => 
            Debug.Log("Progress loaded");

        public void Exit()
        {
            
        }
    }
}
