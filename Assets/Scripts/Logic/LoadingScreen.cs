using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class LoadingScreen : MonoBehaviour
    {
        private readonly float _fadeDelay = 0.03f;
        private readonly float _appearDelay = 0.05f;
        [SerializeField] private CanvasGroup _canvas;

        public void Show() =>
            StartCoroutine(Appear());


        public void Hide() =>
            StartCoroutine(FadeIn());

        private IEnumerator Appear()
        {
            while(_canvas.alpha < 1)
            {
                _canvas.alpha += _fadeDelay;
                yield return new WaitForSeconds(_appearDelay);    
            }
        }

        private IEnumerator FadeIn()
        {
            while (_canvas.alpha > 0)
            {
                _canvas.alpha -= _fadeDelay;
                yield return new WaitForSeconds(_fadeDelay);
            }
        }     
    }
}