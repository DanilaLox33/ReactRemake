using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.Features.DialogSystem
{
    /// <summary>
    ///     Кнопка выбора в диалоговом окне.
    /// </summary>
    public abstract class ChooseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("View")]
        [SerializeField] protected Button button;
        [SerializeField] protected TextMeshProUGUI textButton;
        [SerializeField] protected int cost;

        [Header("Buttons setting")]
        [SerializeField] protected int id;

        protected DialogData CurrentDialog;
        protected Vector3 OriginalScale = Vector3.one;

        public event Action<DialogData> OnChoose;
        public event Action<int> onPointerEnter;
        public event Action onPointerExit;

        protected virtual void OnEnable()
        {
            button.onClick.AddListener(OnChooseButton);
            button.image.alphaHitTestMinimumThreshold = 0.5f;
        }

        protected virtual void OnDisable()
        {
            button.onClick.RemoveListener(OnChooseButton);
            onPointerExit?.Invoke();
        }

        protected virtual void OnChooseButton()
        {
            OnChoose?.Invoke(CurrentDialog);
        }

        /// <summary>
        ///     Установка данных для кнопки.
        /// </summary>
        /// <param name="data"></param>
        public virtual void SetData(DialogData data)
        {
            CurrentDialog = data;
            if (data is ChooseDialogData choose)
            {
                textButton.text = choose.AnswerName;
                button.interactable = CheckCondition(choose);
            }
        }

        /// <summary>
        ///     Проверка условия работы кнопки.
        /// </summary>
        /// <param name="data">
        ///     Данные для проверки./param>
        ///     <returns></returns>
        public abstract bool CheckCondition(ChooseDialogData data);

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnter?.Invoke(id);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            onPointerExit?.Invoke();
        }
        
    }
}