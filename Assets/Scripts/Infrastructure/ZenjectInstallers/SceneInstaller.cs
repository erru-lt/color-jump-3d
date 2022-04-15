using Assets.Scripts.Logic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.ZenjectInstallers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void InstallBindings() => 
            BindLoadingScreen();

        private void BindLoadingScreen() => 
            Container.BindInstance(_loadingScreen);
    }
}
