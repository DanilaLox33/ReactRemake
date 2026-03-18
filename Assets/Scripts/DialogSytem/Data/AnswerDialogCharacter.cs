using System.Collections.Generic;
using UnityEngine;

namespace Project.Features.DialogSystem
{
    [CreateAssetMenu(fileName = "AnswerDialogCharacter", menuName = "DialogSystem/AnswerDialogCharacter")]
    public class AnswerDialogCharacter : ScriptableObject
    {
        [SerializeField] private List<ChooseDialogData> _goodAnswer = new List<ChooseDialogData>();
        [SerializeField] private List<ChooseDialogData> _evilAnswer = new List<ChooseDialogData>();

        public List<ChooseDialogData> GetAnswer(bool isGood)
        {
            return isGood ? _goodAnswer : _evilAnswer;
        }
    }
}