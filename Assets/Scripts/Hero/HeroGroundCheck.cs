using Assets.Scripts.CameraLogic;
using Assets.Scripts.Logic.Platforms;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Hero
{
    public class HeroGroundCheck : MonoBehaviour
    {
        public event Action Landed;

        private CameraShake _cameraShake;

        [Inject]
        public void Construct(CameraShake cameraShake) => 
            _cameraShake = cameraShake;

        private void OnTriggerEnter(Collider other)
        {
            Platform platform = other.gameObject.GetComponent<Platform>();

            if(platform != null)
            {
                Landed?.Invoke();
                _cameraShake.StartShake();
            }
        }
    }
}
