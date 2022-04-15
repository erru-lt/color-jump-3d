using UnityEngine;

namespace Assets.Scripts.UI.UIFactory
{
    public interface IUIFactory
    {
        void CreateMainMenuWindow();
        void CreateLevelCompletedWindow();
        Transform CreateUIRoot();
    }
}