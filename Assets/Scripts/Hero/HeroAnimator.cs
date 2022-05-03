using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(Animator), typeof(CharacterController))]
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int DeathHash = Animator.StringToHash("Death");
        private static readonly int ColorChangeHash = Animator.StringToHash("ColorChange");

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;

        public void PlayDeath() => 
            _animator.SetTrigger(DeathHash);

        public void PlayColorChange() => 
            _animator.SetTrigger(ColorChangeHash);
    }
}
