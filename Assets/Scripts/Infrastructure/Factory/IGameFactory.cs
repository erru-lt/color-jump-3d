using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateHero(Vector3 position);
        void CreateHud();
        void CreateLevelTransitionTrigger(Vector3 position);
    }
}