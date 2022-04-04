using Assets.Scripts.StaticData;
using Assets.Scripts.StaticData.WindowStaticData;
using Assets.Scripts.UI.Window;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string LevelStaticDataPath = "StaticData/Level";
        private const string WindowStaticDataPath = "StaticData/Window/WindowStaticData";

        private Dictionary<string, LevelStaticData> _levelDataDictionary;
        private Dictionary<WindowID, WindowConfig> _windowConfigs;

        public void Load()
        {
            LoadLevelStaticData();
            LoadWindowConfigs();
        }

        public LevelStaticData LevelData(string levelName) =>
            _levelDataDictionary.TryGetValue(levelName, out LevelStaticData levelStaticData)
                ? levelStaticData
                : null;

        public WindowConfig WindowData(WindowID windowID) =>
            _windowConfigs.TryGetValue(windowID, out WindowConfig windowConfig) 
                ? windowConfig 
                : null;

        private void LoadLevelStaticData()
        {
            _levelDataDictionary = Resources
                .LoadAll<LevelStaticData>(LevelStaticDataPath)
                .ToDictionary(x => x.LevelName, x => x);
        }

        private void LoadWindowConfigs()
        {
            _windowConfigs = Resources
                .Load<WindowStaticData>(WindowStaticDataPath)
                .WindowConfigs
                .ToDictionary(x => x.WindowID, x => x);
        }
    }
}
