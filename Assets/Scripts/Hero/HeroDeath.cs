using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Platforms;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        public event Action OnDeath;
        private bool _isDeath;

        [SerializeField] private MeshRenderer _meshRenderer;
        private LoadingScreen _loadingScreen;

        [Inject]
        public void Construct(LoadingScreen loadingScreen) => 
            _loadingScreen = loadingScreen;

        private void Start() => 
            _loadingScreen.Hide();

        public void CheckColorMatch(MeshRenderer meshRenderer)
        {
            if (_meshRenderer.material.color != meshRenderer.material.color)
            {
                Die();
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

        private void Die()
        {
            _isDeath = true;
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
