using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour 
    {
        private const string Level1 = "Level1";

        private SceneLoader _sceneLoader;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }
        
    }
}
