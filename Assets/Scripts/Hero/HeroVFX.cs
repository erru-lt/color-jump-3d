using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _swapParticle;
        [SerializeField] private ParticleSystem _runParticle;
        [SerializeField] private MeshRenderer _meshRenderer;

        public void PlaySwapParticle() => 
            _swapParticle.Play();

        public void PlayRunParticle() => 
            _runParticle.gameObject.SetActive(true);

        public void StopRunParticle() => 
            _runParticle.gameObject.SetActive(false);

        private void LandParticleColor()
        {
            ParticleSystem.MainModule particleSettings = _runParticle.main;
            particleSettings.startColor = new ParticleSystem.MinMaxGradient(_meshRenderer.sharedMaterial.color);
        }
            
    }
}
