using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.StaticData;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Logic
{
    public class TestingFactory : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IGameFactory gameFactory, IStaticDataService staticDataService)
        {
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
        }

        private void Awake()
        {
            GameObject hero = InitializeHero();
            Camera.main.GetComponent<CameraFollow>().Target(hero);
        }

        private GameObject InitializeHero()
        {           
            LevelStaticData levelStaticData = _staticDataService.LevelData(SceneManager.GetActiveScene().name);
            return _gameFactory.CreateHero(levelStaticData.HeroInitialPoint);
        }
    }
}
