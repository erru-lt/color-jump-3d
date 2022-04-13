using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States.StateInterfaces;
using Assets.Scripts.Logic;
using Assets.Scripts.UI.UIFactory;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class MenuState : IPayloadedState<string>
    {
        private readonly IUIFactory _uiFactory;
        private readonly LoadingScreen _loadingScreen;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameStateMachine _gameStateMachine;

        public MenuState(IUIFactory uiFactory, SceneLoader sceneLoader, IGameStateMachine gameStateMachine)
        {
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader; 
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            InitializeUIRoot();
            InitializeMainMenu();
        }

        private void InitializeMainMenu() => 
            _uiFactory.CreateMainMenuWindow();

        private void InitializeUIRoot() =>
            _uiFactory.CreateUIRoot();
    }
}
