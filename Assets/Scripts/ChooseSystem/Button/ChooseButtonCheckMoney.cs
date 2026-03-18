using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Zenject;

namespace Project.Features.DialogSystem
{
    public sealed class ChooseButtonCheckMoney : ChooseButton
    {
        [Inject] private PlayerStat _playerStat;
        [SerializeField] private GameObject _tipWindow;
        [SerializeField] private TextMeshProUGUI popupText;

        private void Awake()
        {
            popupText.text = string.Format(popupText.text, cost);
        }

        public override bool CheckCondition(ChooseDialogData data)
        {
            return _playerStat.Money >= cost;
        }

        protected override void OnChooseButton()
        {
            if (CurrentDialog is ChooseDialogData choose)
            {
                _playerStat.Money -= cost;
            }
            _tipWindow.SetActive(false);
            base.OnChooseButton();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            _tipWindow.SetActive(true);
            base.OnPointerEnter(eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            _tipWindow.SetActive(false);
            base.OnPointerExit(eventData);
        }
    }
}
