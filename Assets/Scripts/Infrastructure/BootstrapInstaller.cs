using Assets.Scripts.Services.InputService;
using Assets.Scripts.Services.StaticDataService;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputService();
        BindStaticDataService();
    }

    private void BindInputService() => 
        Container.Bind<IInputService>().To<InputService>().AsSingle();

    private void BindStaticDataService()
    {
        IStaticDataService staticDataService = new StaticDataService();
        staticDataService.Load();
        Container.Bind<IStaticDataService>().FromInstance(staticDataService).AsSingle();
    }
}
