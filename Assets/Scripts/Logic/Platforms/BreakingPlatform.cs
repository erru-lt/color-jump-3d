using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.Logic.Platforms
{
    public class BreakingPlatform : Platform
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        protected override void OnTriggerEnter(Collider other)
        {
            HeroDeath hero = other.gameObject.GetComponent<HeroDeath>();

            if(hero != null)
            {               
                Destroy(gameObject);
                hero.CheckColorMatch(_meshRenderer);
            }
        }
    }
}
