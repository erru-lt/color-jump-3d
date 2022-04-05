using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Logic.Platforms;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        private bool _isDeath;

        [SerializeField] private MeshRenderer _meshRenderer;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void CheckColorMatch(MeshRenderer meshRenderer)
        {
            if (_meshRenderer.material.color != meshRenderer.material.color)
            {
                RestartGame();
            }
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (_isDeath) return;

            if (hit.gameObject.TryGetComponent(out Platform platform))
            {
                MeshRenderer platformMeshRenderer = platform.GetComponent<MeshRenderer>();
                CheckColorMatch(platformMeshRenderer);
            }
        }

        private void RestartGame()
        {
            Die();
            ReloadScene();
        }

        private void Die()
        {
            _isDeath = true;
            Destroy(gameObject);
        }

        private void ReloadScene() => 
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
    }
}
