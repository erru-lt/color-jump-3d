using Assets.Scripts.Logic;
using Assets.Scripts.Logic.Platforms;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        public event Action OnDeath;

        public bool IsDeath => _isDeath;
        private bool _isDeath;

        [SerializeField] private HeroMovement _heroMovement;
        [SerializeField] private HeroAnimator _animator;
        [SerializeField] private HeroExplosion _heroExplosion;
        [SerializeField] private HeroVFX _heroVFX;
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
                _animator.PlayDeath();
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

        private void OnDeathAnimationStart()
        {
            _isDeath = true;
            _loadingScreen.Show();
            Explode();
            StopRunParticle();
        }

        private void OnDeathAnimationEnd()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }

        private void StopRunParticle() => 
            _heroVFX.StopRunParticle();

        private void Explode() => 
            _heroExplosion.CreateCubes();
    }
}
