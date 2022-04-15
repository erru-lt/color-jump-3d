using Assets.Scripts.StaticData;
using Assets.Scripts.StaticData.WindowStaticData;
using Assets.Scripts.UI.Window;

namespace Assets.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Load();
        LevelStaticData LevelData(string levelName);
        WindowConfig WindowData(WindowID windowID);
    }
}
