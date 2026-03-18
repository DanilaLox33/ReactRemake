using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Project.Features.Person;
using Zenject;

namespace Project.Features.DialogSystem
{
    public class  EventPanel:MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _nameEvent;
        [SerializeField] protected Image _iconEvent;
        [SerializeField] protected TextMeshProUGUI _textEvent;
        private LocalizationController _localizationController;

        [Inject]
        private void Construct(LocalizationController localizationController)
        {
            _localizationController = localizationController;
        }

        public virtual void SetData(PersonEvent data)
        { 
            _nameEvent.text = _localizationController.GetLocalizedText(data.EventName);
            _iconEvent.sprite = data._iconSprite;
            _textEvent.text = _localizationController.GetLocalizedText(data.Descreption);

        }
    }
}