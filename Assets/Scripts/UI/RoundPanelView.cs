using Project.Features.DialogSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace Project.Features.UI
{
    public class RoundPanelView : MonoBehaviour
    {
        [SerializeField] private ResCell _powerCell;
        [SerializeField] private TextMeshProUGUI _phaseText;
        [Inject] private GameController _gameController;

        private void OnEnable()
        {;
            _gameController.ChangePhaseUI += SetPhaseText;
        }

        private void OnDisable()
        {
            _gameController.ChangePhaseUI -= SetPhaseText;
        }

        private void SetPhaseText(int id)
        {
            _phaseText.text = $"Месяц: {id + 1}";
        }
    }
}
