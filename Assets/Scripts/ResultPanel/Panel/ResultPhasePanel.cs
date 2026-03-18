using Project.Features.UI;
using UnityEngine;
using Zenject;

namespace Project.Features.DialogSystem
{
    public class ResultPhasePanel : MonoBehaviour
    {
        [SerializeField] protected ResCell resCells;
        [Inject] private PlayerStat _playerStat;
        [Inject] private ResSystemPhase _resSystemPhase;

        public void SetData()
        {
            _playerStat.Power += _resSystemPhase.Power;
            resCells.SetText(_resSystemPhase.Power);
            _resSystemPhase.Reset();
            gameObject.SetActive(true);
        }
    }
}