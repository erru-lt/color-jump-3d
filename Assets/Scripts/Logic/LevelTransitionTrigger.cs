using Assets.Scripts.Hero;
using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.UI.UIFactory;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic
{
    public class LevelTransitionTrigger : MonoBehaviour
    {
        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        private void OnTriggerEnter(Collider other)
        {
            HeroMovement hero = other.gameObject.GetComponent<HeroMovement>();

            if (hero != null)
            {
                Destroy(hero.gameObject);
                LevelCompleted();
            }
        }

        private void LevelCompleted() => 
            _uiFactory.CreateLevelCompletedWindow();
    }
}
