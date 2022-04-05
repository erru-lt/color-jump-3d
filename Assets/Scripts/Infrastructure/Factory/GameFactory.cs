using Assets.Scripts.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly IAssetProvider _assetProvider;

        [Inject]
        public GameFactory(DiContainer diContainer, IAssetProvider assetProvider)
        {
            _diContainer = diContainer;
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(Vector3 position)
        {
            GameObject heroPrefab = _assetProvider.LoadPrefab(AssetPath.HeroPrefabPath);
            return Object.Instantiate(heroPrefab, position, Quaternion.identity, null);
            //return _diContainer.InstantiatePrefab(heroPrefab, position, Quaternion.identity, null);
        }
    }
}
