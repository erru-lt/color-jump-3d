using UnityEngine;

namespace Assets.Scripts.UI.UIFactory
{
    public interface IUIFactory
    {
        void CreateMainMenuWindow();
        void CreateShopWindow();
        void CreateLevelCompletedWindow();
        Transform CreateUIRoot();
    }
}