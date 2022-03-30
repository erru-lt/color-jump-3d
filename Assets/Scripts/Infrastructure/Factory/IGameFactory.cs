using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateHero(Vector3 position);
    }
}