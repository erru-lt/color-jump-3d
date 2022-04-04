using Assets.Scripts.Logic.Platforms;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        private bool _isDeath;

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
            Destroy(gameObject);
        }
    }
}
