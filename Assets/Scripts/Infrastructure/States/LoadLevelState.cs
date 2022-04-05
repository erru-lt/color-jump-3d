using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States.StateInterfaces;
using Assets.Scripts.Logic;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.StaticData;
using Assets.Scripts.UI.UIFactory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingScreen _loadingScreen;
        private Transform _uiRoot;

        public LoadLevelState(IGameStateMachine gameStateMachine, IGameFactory gameFactory, IStaticDataService staticDataService, IUIFactory uiFactory, SceneLoader sceneLoader, LoadingScreen loadingScreen)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
        }

        public void Enter(string sceneName)
        {
            _loadingScreen.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _loadingScreen.Hide();

        private void OnLoaded()
        {
            InitializeUIRoot();
            InitializeGameWorld();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitializeUIRoot()
        {
            if (_uiRoot != null) return;

            _uiRoot = _uiFactory.CreateUIRoot();
        }

        private void InitializeGameWorld()
        {
            GameObject hero = InitializeHero();
            CameraFollow(hero);
        }

        private GameObject InitializeHero()
        {
            LevelStaticData levelStaticData = _staticDataService.LevelData(SceneManager.GetActiveScene().name);
            return _gameFactory.CreateHero(levelStaticData.HeroInitialPoint);
        }

        private void CameraFollow(GameObject hero) => 
            Camera.main.GetComponent<CameraFollow>().Target(hero);
    }
}
