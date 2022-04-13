using UnityEngine;

namespace Assets.Scripts.StaticData
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelName;
        public Vector3 HeroInitialPoint;
        public Vector3 LevelEndpoint;
        public Color StartColor;
        public Color[] PlatformColors;
    }
}
