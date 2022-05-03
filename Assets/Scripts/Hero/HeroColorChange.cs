using Assets.Scripts.Services.InputService;
using Assets.Scripts.Services.StaticDataService;
using Assets.Scripts.StaticData;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Hero
{
    public class HeroColorChange : MonoBehaviour
    {
        [SerializeField] private HeroVFX _heroVFX;
        [SerializeField] private HeroAnimator _heroAnimator;
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
                _heroAnimator.PlayColorChange();
                _heroVFX.PlaySwapParticle();
                ChangeHeroColor();
            }
        }

        private void ChangeHeroColor()
        {
            LevelStaticData levelStaticData = LevelData();

            for (int i = 0; i < levelStaticData.PlatformColors.Count; i++)
            {
                if(_meshRenderer.sharedMaterial.color != levelStaticData.PlatformColors[i])
                {
                    SwapColors(levelStaticData.PlatformColors[i]);
                    break;
                }
            }
        }

        private void HeroStartColor()
        {
            LevelStaticData levelStaticData = LevelData();

            _meshRenderer.sharedMaterial.color = levelStaticData.StartColor;
        }

        private void SwapColors(Color color) => 
            _meshRenderer.sharedMaterial.color = color;

        private LevelStaticData LevelData() =>
            _staticDataService.LevelData(SceneManager.GetActiveScene().name);
    }
}
