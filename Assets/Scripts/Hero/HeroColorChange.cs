using Assets.Scripts.Services.InputService;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.StaticData;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Hero
{
    public class HeroColorChange : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        private IStaticDataService _staticDataService;
        private IInputService _inputService;

        [Inject]
        public void Construct(IStaticDataService staticDataService, IInputService inputService)
        {
            _staticDataService = staticDataService;
            _inputService = inputService;
        }

        private void Start() => 
            HeroStartColor();

        private void Update() => 
            CheckInput();

        private void CheckInput()
        {
            if(_inputService.IsColorChangeButtonDown())
            {
                ChangeHeroColor();
            }
        }

        private void ChangeHeroColor()
        {
            LevelStaticData levelStaticData = LevelData();

            for (int i = 0; i < levelStaticData.PlatformColors.Length; i++)
            {
                if(_meshRenderer.material.color != levelStaticData.PlatformColors[i])
                {
                    SwapColors(levelStaticData.PlatformColors[i]);
                    break;
                }
            }
        }

        private void SwapColors(Color color) => 
            _meshRenderer.material.color = color;

        private void HeroStartColor()
        {
            LevelStaticData levelStaticData = LevelData();

            _meshRenderer.material.color = levelStaticData.StartColor;
        }

        private LevelStaticData LevelData() =>
            _staticDataService.LevelData(SceneManager.GetActiveScene().name);
    }
}
