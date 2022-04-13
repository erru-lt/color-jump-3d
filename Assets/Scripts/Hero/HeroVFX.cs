using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _runParticle;
        [SerializeField] private ParticleSystem _landParticle;
        [SerializeField] private MeshRenderer _meshRenderer;

        public void PlayRunParticle() => 
            _runParticle.Play();

        public void StopRunParticle() => 
            _runParticle.Stop();

        public void PlayLandParticle()
        {
            LandParticleColor();
            _landParticle.Play();
        }

        private void RunParticleColor() => 
            ParticleColor(_runParticle);

        private void LandParticleColor() => 
            ParticleColor(_landParticle);

        private void ParticleColor(ParticleSystem particle)
        {
            ParticleSystem.MainModule particleSettings = particle.main;
            particleSettings.startColor = new ParticleSystem.MinMaxGradient(_meshRenderer.sharedMaterial.color);
        }
    }
}
