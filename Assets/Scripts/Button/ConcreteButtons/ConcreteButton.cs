using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Features.Command
{
    /// <summary>
    /// Шаблонный класс для реализации кнопок.
    /// </summary>
    /// <typeparam name="TCommand">Команда</typeparam>
    public abstract class ConcreteButton<TCommand> : MonoBehaviour where TCommand : ICommand
    {
        [SerializeField] protected Button button;
        protected ICommand command;

        protected virtual void Awake()
        {
            InitButton();
        }

        protected virtual void OnEnable()
        {
            button.onClick.AddListener(InvokeCommand);
        }

        protected virtual void OnDisable()
        {
            button.onClick.RemoveListener(InvokeCommand);
        }

        /// <summary>
        /// Инициализатор кнопки.
        /// </summary>
        protected abstract void InitButton();

        /// <summary>
        /// Вызов команды.
        /// </summary>
        protected virtual void InvokeCommand()
        {
            command.Execute();
        }
        
        /// <summary>
        /// Инициазлизация кнопки при добавлеии компонента.
        /// </summary>
        private void OnValidate()
        {
            TryGetComponent(out button);
        }
    }
}