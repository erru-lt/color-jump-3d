using Assets.Scripts.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string LevelStaticDataPath = "StaticData/Level";
        private Dictionary<string, LevelStaticData> _levelDataDictionary;

        public void Load() =>
            LoadLevelStaticData();

        public LevelStaticData LevelData(string levelName) =>
            _levelDataDictionary.TryGetValue(levelName, out LevelStaticData levelStaticData)
                ? levelStaticData
                : null;

        private void LoadLevelStaticData()
        {
            _levelDataDictionary = Resources
                .LoadAll<LevelStaticData>(LevelStaticDataPath)
                .ToDictionary(x => x.LevelName, x => x);
        }
    }
}
