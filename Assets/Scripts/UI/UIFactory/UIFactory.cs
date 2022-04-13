using Assets.Scripts.Infrastructure.AssetManagement;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.StaticData.WindowStaticData;
using Assets.Scripts.UI.Elements;
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
            MainMenuWindow mainMenuWindow = Object.Instantiate(mainMenuWindowConfig.WindowPrefab, _uiRoot) as MainMenuWindow;
        }

        public void CreateShopWindow()
        {
            WindowConfig shopWindowConfig = _staticDataService.WindowData(WindowID.Shop);
            ShopWindow shopWindow = Object.Instantiate(shopWindowConfig.WindowPrefab, _uiRoot) as ShopWindow;
        }

        public void CreateLevelCompletedWindow()
        {
            WindowConfig levelCompletedWindowConfig = _staticDataService.WindowData(WindowID.LevelCompleted);
            LevelCompletedWindow levelCompletedWindow = Object.Instantiate(levelCompletedWindowConfig.WindowPrefab, _uiRoot) as LevelCompletedWindow;
        }

        public Transform CreateUIRoot()
        {
            GameObject uiRootPrefab = _assetProvider.LoadPrefab(AssetPath.UIRootPath);
            _uiRoot = Object.Instantiate(uiRootPrefab).transform;

            return _uiRoot;
        }
    }
}
