using Assets.Scripts.Hero;
using Assets.Scripts.Services.WindowService;
using Assets.Scripts.UI.Window;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic
{
    public class LevelTransitionTrigger : MonoBehaviour
    {
        private IWindowService _windowService;

        [Inject]
        public void Construct(IWindowService windowService) => 
            _windowService = windowService;

        private void OnTriggerEnter(Collider other)
        {
            HeroMovement hero = other.gameObject.GetComponent<HeroMovement>();

            if (hero != null)
            {
                Destroy(hero.gameObject);
                LevelCompleted();
            }
        }

        private void LevelCompleted() => 
            _windowService.Open(WindowID.LevelCompleted);
    }
}
