using Assets.Scripts.Hero;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Logic
{
    public class BottomBoundary : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void OnTriggerEnter(Collider other)
        {
            HeroMovement hero = other.gameObject.GetComponent<HeroMovement>();

            if(hero != null)
            {
                ReloadCurrentScene();
            }
        }

        private void ReloadCurrentScene() => 
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
    }
}
