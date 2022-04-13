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

        public LoadLevelState(IGameStateMachine gameStateMachine, IGameFactory gameFactory, IStaticDataService staticDataService, IUIFactory uiFactory, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            InitializeUIRoot();
            InitializeGameWorld();
        }

        private void InitializeUIRoot() => 
            _uiFactory.CreateUIRoot();

        private void InitializeGameWorld()
        {
            LevelStaticData levelStaticData = LevelData();

            GameObject hero = InitializeHero(levelStaticData);
            InitializeLevelTransitionTrigger(levelStaticData);
            CameraFollow(hero);
            EnterNextState(hero);
        }

        private GameObject InitializeHero(LevelStaticData levelStaticData) =>
            _gameFactory.CreateHero(levelStaticData.HeroInitialPoint);

        private void InitializeLevelTransitionTrigger(LevelStaticData levelStaticData) => 
            _gameFactory.CreateLevelTransitionTrigger(levelStaticData.LevelEndpoint);

        private void CameraFollow(GameObject hero) =>
            Camera.main.GetComponent<CameraFollow>().Target(hero);

        private void EnterNextState(GameObject hero) => 
            _gameStateMachine.Enter<GameLoopState, GameObject>(hero);

        private LevelStaticData LevelData() =>
            _staticDataService.LevelData(SceneManager.GetActiveScene().name);
    }
}
