using Project.Features.Person;

namespace Project.Features.DialogSystem
{
    public class EventSpyPanel : EventPanel
    {
        public override void SetData(PersonEvent data)
        {
            _nameEvent.text = data.EventName;
            _iconEvent.sprite = data._iconSprite;
            _textEvent.text = data.Result;
            gameObject.SetActive(true);
        }
    }
}