using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject LoadPrefab(string path);
    }
}