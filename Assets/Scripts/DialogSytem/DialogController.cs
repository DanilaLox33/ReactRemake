using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Project.Features.DialogSystem
{
    public sealed class DialogController : MonoBehaviour
    {
        [SerializeField] private DialogView dialogView;

        [Header("DialogData")] private DialogData _startDialogData;

        private Dialog _currentDialog;
        private Coroutine _dialogCoroutine;

        private DialogData _currentData;

        public bool canPlay;
        private GameInput _input;

        [Inject]
        private void Construct(GameInput input)
        {
            _input = input;
        }

        private void OnEnable()
        {
            _input.SubClick(MouseClick);
        }

        private void MouseClick(InputAction.CallbackContext obj)
        {
            if (!canPlay) return;
            if (_dialogCoroutine == null)
                NextPart();
        }

        private void OnDisable()
        {
            _input.UnSubClick(MouseClick);
        }

        public void SetDialog(DialogData data)
        {
            _currentData = null;
            _currentData = data;
            _currentDialog = new Dialog(data);
            _currentDialog.OnEndDialog += CompleteDialog;
            NextPart();
        }

        private void CompleteDialog()
        {
            _currentDialog.OnEndDialog -= CompleteDialog;

            if (_currentData.dialogEvent != null) _currentData.dialogEvent.Invoke();

            if (_currentData.Next != null) SetDialog(_currentData.Next);
        }

        public IEnumerator ShowDialog(DialogData data)
        {
            foreach (var dialog in data.Dialogs)
            {
                dialogView.SetData(dialog);
                yield return dialogView.ShowText(dialog.PersonText);
            }

            yield return null;
        }

        private IEnumerator ShowDialogPart(DialogPart dialog)
        {
            dialogView.SetData(dialog);
            yield return dialogView.ShowText(dialog.PersonText);
            _dialogCoroutine = null;
        }

        private void NextPart()
        {
            if (_dialogCoroutine != null || _currentDialog == null) return;

            var dialog = _currentDialog.GetNextPart();

            if (dialog == null) return;


            _dialogCoroutine = StartCoroutine(ShowDialogPart(dialog));

            if (_currentDialog.DialogComplete)
            {
                _currentDialog.OnEndDialog?.Invoke();
                _currentDialog = null;
            }
        }

        public void CloseDialogPanel()
        {
            gameObject.SetActive(false);
        }

        public void SetPlay(bool isPlay)
        {
            canPlay = isPlay;
        }
    }
}