using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Project.Features.DialogSystem
{
    public sealed class SelectKillCell : SelectCell
    {
        [Inject] private PlayerStat _stats;
        [SerializeField] private int power = 3;
        [SerializeField] private ResultKillPanel panel;
        [SerializeField] private int timeShow = 5;
        private bool _isGood;

        public override void SetEvent(Person.Person person, int id)
        {
            _isGood = person.isGood;
            base.SetEvent(person, id);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            ShowResult();
        }

        private async void ShowResult()
        {
            _stats.Power += _isGood ? -power : power;
            panel.OpenPanel(_isGood);
            await UniTask.Delay(timeShow); 
            OnPointClick?.Invoke();
        }
    }
}