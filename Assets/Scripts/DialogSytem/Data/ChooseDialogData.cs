using System;
using UnityEngine;

namespace Project.Features.DialogSystem
{
    public sealed class ChooseDialogData : DialogData
    {
        [Header("ChooseSetting")] public NameChoose NameChoose = NameChoose.FullMoney;
        public int Power = 3;

        [HideInInspector] public string AnswerName = string.Empty;

        private void OnValidate()
        {
            SetName(NameChoose);
        }

        private void SetName(NameChoose nameChoose)
        {
            AnswerName = nameChoose switch
            {
                NameChoose.FullMoney => "100",
                NameChoose.PartialMoney => "50",
                NameChoose.NoMoney => "0",
                _ => throw new ArgumentOutOfRangeException(nameof(nameChoose), nameChoose, null)
            };
        }
    }

    [Serializable]
    public enum NameChoose
    {
        FullMoney,
        PartialMoney,
        NoMoney,
    }
}