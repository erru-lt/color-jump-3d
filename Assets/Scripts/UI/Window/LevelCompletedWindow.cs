using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Window
{
    public class LevelCompletedWindow : WindowBase
    {
        private const string MenuScene = "Menu";

        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _reloadLevelButton;
        [SerializeField] private Button _nextLevelButton;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake()
        {
            MenuButton();
            ReloadLevelButton();
            NextLevelButton();
        }

        private void MenuButton() => 
            _menuButton.onClick.AddListener(() => LoadMenu());

        private void ReloadLevelButton() => 
            _reloadLevelButton.onClick.AddListener(() => ReloadLevel());

        private void NextLevelButton() => 
            _nextLevelButton.onClick.AddListener(() => LoadNextLevel());

        private void LoadMenu() => 
            _gameStateMachine.Enter<MenuState, string>(MenuScene);

        private void ReloadLevel() => 
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);

        private void LoadNextLevel() => 
            _gameStateMachine.Enter<LoadLevelState, string>("Level2");
    }
}
