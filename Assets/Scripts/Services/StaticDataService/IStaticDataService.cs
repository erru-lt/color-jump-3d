
using Assets.Scripts.StaticData;

namespace Assets.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        LevelStaticData LevelData(string levelName);
        void Load();
    }
}
