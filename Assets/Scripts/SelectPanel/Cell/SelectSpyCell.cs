using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Features.DialogSystem
{
    public class SelectSpyCell : SelectCell
    {
        [SerializeField] protected SpySystem spyButton;
        public override void OnPointerClick(PointerEventData eventData)
        {
            spyButton.SetCurrentEvent(CurrentEvent);
            OnPointClick?.Invoke();
            personIcon.color = Color.white;
        }
    }
}