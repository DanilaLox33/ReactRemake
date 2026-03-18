using System;
using Project.Features.Game;
using Project.Features.Person;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Zenject;

namespace Project.Features.DialogSystem
{
    public class GameController : MonoBehaviour
    {
        [Header("Game panels")] 
        [SerializeField] private ChoosePanel choosePanel;
        [SerializeField] private SelectPanel selectPanel;
        [SerializeField] private EndPanel endPanel;
        [SerializeField] private ResultPhaseSystem resultPhaseSystem;

        [FormerlySerializedAs("_completeDialogEvent")]
        [Header("Game events")] 
        [SerializeField] private DialogEvent completeDialogEvent;
        [FormerlySerializedAs("_choosePanelOpen")] [SerializeField] private DialogEvent choosePanelOpen;

        [Header("Game setting")] [SerializeField]
        private int _lastPhase = 2;

        [Inject] private PlayerStat _playerStat;
        [Inject] private PersonController _personController;
        [Inject] private DialogController _dialogController;
        [Inject] private GameInput _gameInput;
        [Inject] private AnimationController _animationController;

        private PersonEvent _currentEvent;

        private int _currentPhase;
        private bool _isFinished;
        private bool _isSelectIcon;

        public event Action<int> OnPhaseChange;
        public event Action<int> ChangePhaseUI;

        [Inject] private AudioController _audioController;

        public int CurrentPhase
        {
            get => _currentPhase;

            set
            {
                _currentPhase = value;
                OnPhaseChange?.Invoke(_currentPhase);
            }
        }

        private void Start()
        {
            InitGame();
        }

        private void InitGame()
        {
            _personController.GenerateGame();
            choosePanel.Init();
            _audioController.SetMusic("BackgroundMusic");
            GetNextStep();
        }


        private void GetNextStep()
        {
            if (_isFinished)
            {
                resultPhaseSystem.Open();
                return;
            }

            if (_isSelectIcon)
            {
                _dialogController.canPlay = false;
                selectPanel.OpenPanel(_currentPhase - 1);
                _isSelectIcon = false;
                return;
            }

            if (_lastPhase <= _currentPhase)
            {
                endPanel.OpenEndPanel();
                return;
            }

            _currentEvent = _personController.GetHero(_currentPhase);
            choosePanel.SetData(_currentEvent);
            _dialogController.SetDialog(_currentEvent.DialogData);
        }

        private void SetNext()
        {
            _personController.CurrentPerson++;
            GetNextStep();
        }

        private void OnEnable()
        {
            _personController.OnComplete += SetNextPhase;
            completeDialogEvent.Event += SetNext;
            choosePanelOpen.Event += OpenChoosePanel;
            resultPhaseSystem.OnComplete += CompletePhase;
            OnPhaseChange += selectPanel.OpenPanel;
            _gameInput.SubSkip(SetSkip);
            _gameInput.SubStopSkip(StopSkip);
        }

        private void StopSkip(InputAction.CallbackContext obj)
        {
            _animationController.ChangeSpeed(1);
        }

        private void SetSkip(InputAction.CallbackContext obj)
        {
            _animationController.ChangeSpeed(5);
        }

        private void OnDisable()
        {
            _personController.OnComplete -= SetNextPhase;
            completeDialogEvent.Event -= SetNext;
            choosePanelOpen.Event -= OpenChoosePanel;
            resultPhaseSystem.OnComplete -= CompletePhase;
            OnPhaseChange -= selectPanel.OpenPanel;
            _gameInput.UnSubSkip(SetSkip);
            _gameInput.UnSubStopSkip(StopSkip);
        }

        private void OpenChoosePanel()
        {
            choosePanel.gameObject.SetActive(true);
            _dialogController.canPlay = false;
        }

        private void CompletePhase()
        {
            _isFinished = false;
            _playerStat.ResetStat();
            GetNextStep();
        }

        private void SetNextPhase()
        {
            _currentPhase++;
            ChangePhaseUI?.Invoke(_currentPhase);
            _isFinished = true;
            _isSelectIcon = true;
        }

        public void CompleteSelect()
        {
            _dialogController.canPlay = true;
            GetNextStep();
        }
    }
}