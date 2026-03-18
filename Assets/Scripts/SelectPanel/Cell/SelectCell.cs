
namespace Project.Features.DialogSystem
{
    using System;

    using Project.Features.Person;

    using TMPro;

    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    public class SelectCell : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] protected Image personIcon;
        [SerializeField] protected TextMeshProUGUI personName;
        protected PersonEvent CurrentEvent;

        public Action OnPointClick;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            personIcon.color = Color.white;
        }

        public virtual void SetEvent(Person person, int id)
        {
            CurrentEvent = person.GetEvent(id);
            SetView(CurrentEvent);
        }

        protected virtual void SetView(PersonEvent person)
        {
            personIcon.sprite = person.DialogCharacter.Icon;
            personName.text = person.DialogCharacter.Name;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            personIcon.color = Color.darkGreen;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            personIcon.color = Color.white;
        }
    }
}