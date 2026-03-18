using System.Collections.Generic;
using Project.Features.Person;
using UnityEngine;
using Zenject;

namespace Project.Features.DialogSystem
{
    public sealed class ChoosePanel : MonoBehaviour
    {
        [SerializeField] private EventPanel eventPanel;
        [SerializeField] private List<ChooseButton> chooseButtons = new();

        [SerializeField] private ReactPanel reactPanel;

        [Inject] private DialogController _dialogController;

        public void Init()
        {
            foreach (var button in chooseButtons)
            {
                button.OnChoose += SetChoose;
                button.onPointerEnter += reactPanel.SetSprite;
                button.onPointerExit += reactPanel.ReturnOriginalSprite;
            }
        }

        private void SetChoose(DialogData part)
        {
            _dialogController.SetDialog(part);
            _dialogController.canPlay = true;
            reactPanel.ReturnOriginalSprite();
            gameObject.SetActive(false);
        }

        public void SetData(PersonEvent data)
        {
            reactPanel.SetData(data.DialogCharacter);
            eventPanel.SetData(data);

            var answers = data.Answers.GetAnswer(data.isGood);

            foreach (var button in chooseButtons)
                for (var i = 0; i < answers.Count; i++)
                    chooseButtons[i].SetData(answers[i]);
        }

        private void OnDestroy()
        {
            foreach (var button in chooseButtons)
            {
                button.OnChoose -= SetChoose;
                button.onPointerEnter -= reactPanel.SetSprite;
                button.onPointerExit -= reactPanel.ReturnOriginalSprite;
            }
        }
    }
}