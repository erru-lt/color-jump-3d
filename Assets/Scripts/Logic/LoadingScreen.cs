using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LoadingScreen : MonoBehaviour
    {
        private readonly float _delay = 0.03f;
        [SerializeField] private CanvasGroup _canvas;

        public void Hide() =>
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while (_canvas.alpha > 0)
            {
                _canvas.alpha -= _delay;
                yield return new WaitForSeconds(_delay);
            }

            gameObject.SetActive(false);
        }     
    }
}