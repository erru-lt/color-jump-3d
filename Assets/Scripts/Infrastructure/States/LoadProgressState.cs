using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States.StateInterfaces;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string MenuScene = "Menu";
        private readonly IGameStateMachine _gameStateMachine;

        public LoadProgressState(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter() => 
            _gameStateMachine.Enter<MenuState, string>(MenuScene);

        private void LoadProgress()
        {

        }

        public void Exit()
        {
            
        }
    }
}
