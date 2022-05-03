using Assets.Scripts.Hero;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States.StateInterfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.States
{
    public class GameLoopState : IPayloadedState<GameObject>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private GameObject _hero;

        public GameLoopState(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter(GameObject hero)
        {
            _hero = hero;
            SubscribeOnHero(_hero);
        }

        public void Exit()
        {

        }

        private void OnHeroDeath()
        {
            ReloadCurrentScene();
            UnsubscribeOnHero(_hero);
        }

        private void SubscribeOnHero(GameObject hero)
        {
            if (IsHero(hero, out HeroDeath heroDeath))
            {
                heroDeath.OnDeath += OnHeroDeath;
            }
        }

        private void UnsubscribeOnHero(GameObject hero)
        {
            if (IsHero(hero, out HeroDeath heroDeath))
            {
                heroDeath.OnDeath -= OnHeroDeath;
            }
        }

        private bool IsHero(GameObject hero, out HeroDeath heroDeath) =>
            hero.TryGetComponent<HeroDeath>(out heroDeath);

        private void ReloadCurrentScene() =>
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
    }
}