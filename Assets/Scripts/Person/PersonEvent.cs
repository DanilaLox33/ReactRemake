using Project.Features.DialogSystem;

using UnityEngine;
using Zenject;

namespace Project.Features.Person
{
    [CreateAssetMenu(fileName = "PersonEvent", menuName = "Characters/PersonEvent")]
    public class PersonEvent : ScriptableObject
    {
        [Header("View setting")]

        public Sprite _iconSprite;
        public bool isGood = false;

        [Header("Choose settig")]
        public DialogData DialogData;
        public AnswerDialogCharacter Answers;

        public DialogCharacter DialogCharacter;
        
        
        public string EventName { get => ($"{name}_name"); }
        public string Descreption { get => ($"{name}"); }
        public string Result { get =>(isGood ? $"{name}_good_result" : $"{name}_evil_result)"); }
    }
}