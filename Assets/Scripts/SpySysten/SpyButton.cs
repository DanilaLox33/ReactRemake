using UnityEngine;
using Project.Features.Person;

namespace Project.Features.Command
{
    public sealed class SetSpySystemCommand : ICommand
    {
        private SpySystem _spySystem;

        public SetSpySystemCommand(SpySystem spySystem)
        {
            _spySystem = spySystem;
        }

        public void Execute()
        {
            _spySystem.TargetEvent();
        }
    }

    public class SpyButton : ConcreteButton<SetSpySystemCommand>
    {
        [SerializeField] private SpySystem spySystem;
        protected PersonEvent currentEvent;

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public void SetEvent(PersonEvent person)
        {
            currentEvent = person;
        }

        protected override void InitButton()
        {
            command = new SetSpySystemCommand(spySystem);
        }

        protected override void InvokeCommand()
        {
            spySystem.SetCurrentEvent(currentEvent);
        }
    }
}