using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Project.Features.DialogSystem
{
    public sealed class ChooseButtonCondition : ChooseButton
    {
        [Inject] private ResSystemPhase _resSystemPhase;

        public override bool CheckCondition(ChooseDialogData data)
        {
            return true;
        }

        protected override void OnChooseButton()
        {
            if (CurrentDialog is ChooseDialogData choose)
            {
                _resSystemPhase.Power += choose.Power * cost;
            }

            base.OnChooseButton();
        }
    }
}