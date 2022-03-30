using UnityEngine;

namespace Assets.Scripts.StaticData
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public Vector3 HeroInitialPoint;
        public string LevelName;
        public Color StartColor;
        public Color[] PlatformColors;
    }
}
