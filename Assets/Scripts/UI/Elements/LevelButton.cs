using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Elements
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Button _selectLevelButton;
        [SerializeField] private TMP_Text _levelName;

        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake() => 
            SelectLevelButton();

        private void SelectLevelButton() => 
            _selectLevelButton.onClick.AddListener(() => LoadLevel());

        private void LoadLevel() => 
            _gameStateMachine.Enter<LoadLevelState, string>("Level1");
    }
}
