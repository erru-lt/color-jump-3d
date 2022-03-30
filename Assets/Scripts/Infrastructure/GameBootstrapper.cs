using Assets.Scripts.Infrastructure.StateMachine;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour 
    {
        private const string Level1 = "Level1";

        private SceneLoader _sceneLoader;
        private IGameStateMachine _gameStateMachine;

        
        public void Construct(IGameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
               
        }
        
    }
}
