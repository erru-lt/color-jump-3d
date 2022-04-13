using Assets.Scripts.Infrastructure.AssetManagement;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Logic;
using Assets.Scripts.Services.InputService;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.Services.WindowService;
using Assets.Scripts.UI.UIFactory;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.ZenjectInstallers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private LoadingScreen _loadingScreenPrefab;

        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindSceneLoader();
            BindInputService();
            BindAssetProviderService();
            BindGameFactory();
            BindStaticDataService();
            BindWindowService();
            BindUIFactory();
        }


        private void BindGameStateMachine() => 
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

        private void BindSceneLoader()
        {
            SceneLoader sceneLoader = new SceneLoader(this);
            Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle();
        }

        private void BindInputService() => 
            Container.Bind<IInputService>().To<InputService>().AsSingle();

        private void BindAssetProviderService() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindGameFactory() =>
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

        private void BindStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.Load();
            Container.Bind<IStaticDataService>().FromInstance(staticDataService).AsSingle();
        }

        private void BindWindowService() => 
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();

        private void BindUIFactory() => 
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();       
    }
}