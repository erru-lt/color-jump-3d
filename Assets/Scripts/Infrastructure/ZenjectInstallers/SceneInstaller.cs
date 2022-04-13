using Assets.Scripts.Logic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.ZenjectInstallers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void InstallBindings()
        {
            Container.BindInstance(_loadingScreen);
            //LoadingScreen loadingScreen = Container.InstantiatePrefabForComponent<LoadingScreen>(_loadingScreen);
            //Container.Bind<LoadingScreen>().FromInstance(loadingScreen).AsSingle();
        }
    }
}
