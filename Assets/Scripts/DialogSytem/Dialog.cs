using System;
using System.Collections.Generic;

namespace Project.Features.DialogSystem
{
    public sealed class Dialog
    {
        private int _dialogCout = 1;
        private int _currentDialogIndex;

        public event Action OnStartDialog;
        public Action OnEndDialog;

        private readonly List<DialogPart> _dialogParts = new();
        public bool DialogComplete => _currentDialogIndex > _dialogCout;

        private int CurrentDialogIndex
        {
            get => _currentDialogIndex;
            set
            {
                if (value > _dialogCout) OnEndDialog?.Invoke();
                _currentDialogIndex = value;
            }
        }

        public Dialog(DialogData data)
        {
            if (data == null)
                return;
            _dialogCout = data.Dialogs.Count;
            _currentDialogIndex = 0;
            _dialogParts = data.Dialogs;

            OnStartDialog?.Invoke();
        }

        public DialogPart GetNextPart()
        {
            if (_currentDialogIndex >= _dialogCout)
            {
                OnEndDialog?.Invoke();
                return null;
            }

            var data = _dialogParts[_currentDialogIndex];
            CurrentDialogIndex++;
            return data;
        }
    }
}