using Assets.Scripts.Services.WindowService;
using Assets.Scripts.UI.Window;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Elements
{
    public class TestButton : MonoBehaviour
    {
        private IWindowService _windowService;
        [SerializeField] private WindowID _windowID;
        [SerializeField] private Button _shopButton;

        [Inject]
        public void Construct(IWindowService windowService) => 
            _windowService = windowService;

        private void Awake() => 
            ShopButton();

        private void ShopButton() => 
            _shopButton.onClick.AddListener(() => CreateShop());

        private void CreateShop() => 
            _windowService.Open(_windowID);
    }
}
