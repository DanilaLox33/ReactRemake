using Project.Features.Game;

using TMPro;

using UnityEngine;
using Zenject;

namespace Project.Features.DialogSystem
{
    public class ResultKillPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resText;
        [SerializeField] private TextMeshProUGUI _powerText;
        [Inject] private PlayerStat _playerStat;
        [Inject] private ResSystemPhase _resSystemPhase;

        public void OpenPanel(bool isGood)
        {
            _playerStat.Power += _resSystemPhase.Power;
            _resSystemPhase.Reset();

            _resText.text = isGood ? "Lose" : "Win!";
            _powerText.text = $"{_playerStat.Power}";

            gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}