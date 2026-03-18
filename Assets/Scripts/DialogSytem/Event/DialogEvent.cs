using System;
using UnityEngine;

namespace Project.Features.DialogSystem
{
    [CreateAssetMenu(fileName = "DialogSystem", menuName = "DialogSystem/DialogEvent")]
    public class DialogEvent : ScriptableObject
    {
        public event Action Event;

        public virtual void Invoke()
        {
            Event?.Invoke();
        }
    }
}