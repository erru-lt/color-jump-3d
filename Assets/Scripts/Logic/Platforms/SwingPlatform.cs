using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.Logic.Platforms
{
    public class SwingPlatform : Platform
    {
        private static readonly int Swing = Animator.StringToHash("Swing");
        [SerializeField] private Animator _animator;

        protected override void OnTriggerEnter(Collider other)
        {
            HeroMovement hero = other.gameObject.GetComponent<HeroMovement>();

            if(hero != null)
            {
                PlaySwingAnimation();
            }
        }

        private void PlaySwingAnimation() => 
            _animator.SetTrigger(Swing);
    }
}
