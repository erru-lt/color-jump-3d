using Assets.Scripts.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        [Inject]
        public GameFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public GameObject CreateHero(Vector3 position)
        {
            GameObject heroPrefab = _assetProvider.LoadPrefab(AssetPath.CubeHeroPrefabPath);
            return Object.Instantiate(heroPrefab, position, Quaternion.identity, null);
        }

        public void CreateHud()
        {
            GameObject hudPrefab = _assetProvider.LoadPrefab(AssetPath.HudPath);
            Object.Instantiate(hudPrefab);
        }

        public void CreateLevelTransitionTrigger(Vector3 position)
        {
            GameObject levelTransitionTriggerPrefab = _assetProvider.LoadPrefab(AssetPath.LevelTransitionTriggerPath);
            Object.Instantiate(levelTransitionTriggerPrefab, position, Quaternion.identity, null);
        }
    }
}
