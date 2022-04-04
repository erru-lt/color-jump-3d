using Assets.Scripts.Logic.Platforms;
using System;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroGroundCheck : MonoBehaviour
    {
        public event Action Landed;

        private void OnTriggerEnter(Collider other)
        {
            Platform platform = other.gameObject.GetComponent<Platform>();

            if(platform != null)
            {
                Landed?.Invoke();
            }
        }
    }
}
