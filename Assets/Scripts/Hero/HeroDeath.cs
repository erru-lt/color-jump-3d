using Assets.Scripts.Logic;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        private bool _isDeath;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (_isDeath) return;

            if (hit.gameObject.TryGetComponent(out Platform platform))
            {
                MeshRenderer platformMeshRenderer = platform.GetComponent<MeshRenderer>();
                CheckColorMatch(platformMeshRenderer);
            }
        }

        private void CheckColorMatch(MeshRenderer meshRenderer)
        {
            if (_meshRenderer.material.color != meshRenderer.material.color)
            {
                _isDeath = true;
            }
        }
    }
}
