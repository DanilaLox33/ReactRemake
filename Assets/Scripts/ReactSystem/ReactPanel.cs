using System.Collections.Generic;


using UnityEngine;
using UnityEngine.UI;

namespace Project.Features.DialogSystem
{

    public class ReactPanel : MonoBehaviour
    {
        [SerializeField] private Image _reactImnage;
        private List<Sprite> _reacts = new();
        private Sprite _originalSprite;
        private Vector3 _originalScale;
        private int _currentSpriteId = 1;

        public void SetData(DialogCharacter person)
        {
            _reacts = person.ReactSprities;
            _reactImnage.sprite = _originalSprite;
            _originalSprite = person.OriginSprite;
        }

        private void OnEnable()
        {
            _reactImnage.sprite = _originalSprite;
            _originalScale = _reactImnage.transform.localScale;
        }

        public void SetSprite(int id)
        {
            if (_currentSpriteId == id)
                return;

            _currentSpriteId = id;
        }

        public void ReturnOriginalSprite()
        {
            if (_currentSpriteId == 1)
                return;

            _currentSpriteId = 1;
        }
    }
}