using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject LoadPrefab(string path) =>
            Resources.Load<GameObject>(path);
    }
}
