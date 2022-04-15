using Assets.Scripts.UI.UIFactory;
using Assets.Scripts.UI.Window;
using Zenject;

namespace Assets.Scripts.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        [Inject]
        public WindowService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Open(WindowID windowID)
        {
            switch(windowID)
            {
                case WindowID.MainMenu:
                    _uiFactory.CreateMainMenuWindow();
                    break;

                case WindowID.LevelCompleted:
                    _uiFactory.CreateLevelCompletedWindow();
                    break;
            }
        }
    }
}
