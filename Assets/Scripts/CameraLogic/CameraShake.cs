using System.Collections;
using UnityEngine;

namespace Assets.Scripts.CameraLogic
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _shakingDuration;
        [SerializeField] private AnimationCurve _shakeCurve;

        public void StartShake() => 
            StartCoroutine(Shaking());

        private IEnumerator Shaking()
        {
            float delay = 0.0f;

            while (delay < _shakingDuration)
            {
                delay += Time.deltaTime;
                float shakeStrength = _shakeCurve.Evaluate(delay / _shakingDuration);

                transform.position +=  Random.insideUnitSphere * shakeStrength;

                yield return null;
            }
        }
    }
}
