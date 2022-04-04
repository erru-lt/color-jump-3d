using Assets.Scripts.Hero;
using Assets.Scripts.Infrastructure;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic
{
    public class LevelTransitionTrigger : MonoBehaviour
    {
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(SceneLoader sceneLoader) => 
            _sceneLoader = sceneLoader;

        private void OnTriggerEnter(Collider other)
        {
            HeroMovement hero = other.gameObject.GetComponent<HeroMovement>();

            if (hero != null)
            {
                _sceneLoader.Load("Level2");
                Destroy(hero.gameObject);
            }
        }
    }
}
