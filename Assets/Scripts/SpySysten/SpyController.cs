using System.Collections.Generic;
using UnityEngine;
using Project.Features.Person;

namespace Project.Features.DialogSystem
{
    public class SpyController : MonoBehaviour
    {
        [SerializeField] protected List<SelectCell> spyCells = new();
        [SerializeField] protected PersonController personController;

        public void SetEvent(int id)
        {
            for (int i = 0; i < spyCells.Count; i++)
            {
                spyCells[i].SetEvent(personController.People[i], (id));
            }
        }
    }
}