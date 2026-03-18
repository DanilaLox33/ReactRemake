using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Features.DialogSystem
{

    public enum DialogType
    {
        Normal,
        Screaming,
        Mumbler,
    }
    [Serializable]

    public class DialogPart
    {
        public DialogCharacter Character;
        public string PersonText;
    }

    [CreateAssetMenu(fileName = "DialogData", menuName = "DialogSystem/DialogData")]
    public class DialogData:ScriptableObject
    {
        [SerializeField] protected List<DialogPart> dialogs= new List<DialogPart>();
        public DialogData Next;
        
        public DialogEvent dialogEvent;

        public List<DialogPart> Dialogs { get { return dialogs; } private set => Dialogs = value; }
    }
}