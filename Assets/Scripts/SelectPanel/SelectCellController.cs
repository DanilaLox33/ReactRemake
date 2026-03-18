using System;
using System.Collections.Generic;

using Project.Features.Person;

using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Project.Features.DialogSystem
{

    public sealed class SelectCellController : MonoBehaviour
    {
        [SerializeField] private List<SelectCell> spyCells = new();
        [Inject] private PersonController _personController;
        [Inject] private GameController _gameController;

        public event Action OnSelect;

        private void OnEnable()
        {
            foreach (var t in spyCells)
            {
                t.OnPointClick += ClosePanel;
            }
        }

        private void OnDisable()
        {
            foreach (var t in spyCells)
            {
                t.OnPointClick -= ClosePanel;
            }
        }

        public void SetEvent(int id)
        {
            for (var i = 0; i < spyCells.Count; i++)
            {
                spyCells[i].SetEvent(_personController.People[i], id);
            }
        }

        private void ClosePanel()
        {
            _gameController.CompleteSelect();
            gameObject.SetActive(false);
            OnSelect?.Invoke();
        }
    }
}