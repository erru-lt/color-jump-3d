using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.StaticData;
using Assets.Scripts.UI.UIFactory;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(IGameFactory gameFactory, IStaticDataService staticDataService, IUIFactory uiFactory, SceneLoader sceneLoader)
        {
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        {
            InitializeUIRoot();
            InitializeGameWorld();
        }

        private void InitializeUIRoot() => 
            _uiFactory.CreateUIRoot();

        private void InitializeGameWorld()
        {
            GameObject hero = InitializeHero();
            CameraFollow(hero);
        }

        private GameObject InitializeHero()
        {
            LevelStaticData levelStaticData = _staticDataService.LevelData("Level1");
            return _gameFactory.CreateHero(levelStaticData.HeroInitialPoint);
        }

        private void CameraFollow(GameObject hero) => 
            Camera.main.GetComponent<CameraFollow>().Target(hero);

        public void Exit()
        {
            
        }
    }
}
