using Assets.Scripts.Infrastructure.AssetManagement;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.StaticData.WindowStaticData;
using Assets.Scripts.UI.Window;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;

        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        [Inject]
        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public void CreateMainMenuWindow()
        {
            WindowConfig mainMenuWindowConfig = _staticDataService.WindowData(WindowID.MainMenu);
            Object.Instantiate(mainMenuWindowConfig.WindowPrefab, _uiRoot);
        }

        public void CreateLevelCompletedWindow()
        {
            WindowConfig levelCompletedWindowConfig = _staticDataService.WindowData(WindowID.LevelCompleted);
            Object.Instantiate(levelCompletedWindowConfig.WindowPrefab, _uiRoot);
        }

        public Transform CreateUIRoot()
        {
            GameObject uiRootPrefab = _assetProvider.LoadPrefab(AssetPath.UIRootPath);
            _uiRoot = Object.Instantiate(uiRootPrefab).transform;

            return _uiRoot;
        }
    }
}
