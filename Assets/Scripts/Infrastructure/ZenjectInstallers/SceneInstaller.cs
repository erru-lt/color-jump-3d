using Assets.Scripts.CameraLogic;
using Assets.Scripts.Logic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure.ZenjectInstallers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private CameraShake _cameraShake;
        public override void InstallBindings()
        {
            BindLoadingScreen();
            BindCameraShake();
        }

        private void BindLoadingScreen() => 
            Container.BindInstance(_loadingScreen);

        private void BindCameraShake() => 
            Container.BindInstance(_cameraShake);
    }
}
