using Assets.Scripts.Infrastructure.States.StateInterfaces;
using Assets.Scripts.Services.WindowService;
using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.UI.Window;

namespace Assets.Scripts.Infrastructure.States
{
    public class MenuState : IPayloadedState<string>
    {
        private readonly IUIFactory _uiFactory;
        private readonly IWindowService _windowService;
        private readonly SceneLoader _sceneLoader;

        public MenuState(IUIFactory uiFactory, IWindowService windowService, SceneLoader sceneLoader)
        {
            _uiFactory = uiFactory;
            _windowService = windowService;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            InitializeUIRoot();
            InitializeMainMenu();
        }

        private void InitializeMainMenu() =>
            _windowService.Open(WindowID.MainMenu);

        private void InitializeUIRoot() =>
            _uiFactory.CreateUIRoot();
    }
}
