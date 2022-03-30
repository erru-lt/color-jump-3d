using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(Animator))]
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int Jump = Animator.StringToHash("Jump");

        [SerializeField] private Animator _animator;

        public void PlayJump() => 
            _animator.SetTrigger(Jump);
    }
}
