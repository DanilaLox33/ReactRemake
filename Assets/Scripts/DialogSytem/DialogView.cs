using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Features.DialogSystem
{
    public class DialogView : MonoBehaviour, IAnimation
    {
        [SerializeField] protected Image personIcon;
        [SerializeField] protected TextMeshProUGUI personName;
        [SerializeField] protected TextMeshProUGUI personText;

        [SerializeField] protected new Animation animation;

        [SerializeField] protected float dialogSpeed = 0.5f;

        private float _speed = 1f;
        private AnimationController _animationController;
        private LocalizationController _localizationController;
        public float Speed => _speed;

        [Inject]
        public void Construct(AnimationController animationController, LocalizationController localizationController)
        {
            _animationController = animationController;
            _localizationController = localizationController;
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void SetData(DialogPart dialogPart)
        {
            personIcon.sprite = dialogPart.Character.Icon;
            personName.text = dialogPart.Character.Name;
            personText.text = dialogPart.PersonText;
        }

        public void ShowTextFast(string text)
        {
            personText.text = string.Empty;
            personText.text = text;
        }

        public IEnumerator ShowText(string dialogText)
        {
            dialogText = _localizationController.GetLocalizedText(dialogText);
    
            personText.text = string.Empty;
            var sb = new StringBuilder();

            foreach (var literal in dialogText)
            {
                sb.Append(literal);
                personText.text = sb.ToString();
        
                if (char.IsPunctuation(literal))
                {
                    yield return new WaitForSeconds(dialogSpeed * 5f / _speed);
                    continue;
                }

                yield return new WaitForSeconds(dialogSpeed / _speed);
            }
        }

        public void Subscribe()
        {
            _animationController.AddAnimation(this);
        }

        public void Unsubscribe()
        {
            _animationController.RemoveAnimation(this);
        }

        public void ChangeSpeed(float speed)
        {
            _speed = speed;
        }
    }
}