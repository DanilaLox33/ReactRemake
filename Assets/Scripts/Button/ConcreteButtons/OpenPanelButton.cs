using UnityEngine;
namespace Project.Features.Command
{
    /// <summary>
    /// Кнопка открытия панели.
    /// </summary>
    public sealed class OpenPanelButton : ConcreteButton<OpenPanelCommand>
    {
        [SerializeField] private GameObject _panel;

        protected override void InitButton()
        {
            command = new OpenPanelCommand(_panel);
        }
    }
}