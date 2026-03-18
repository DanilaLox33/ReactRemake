namespace Project.Features.Command
{
    using UnityEngine;
    public sealed class OpenPanelCommand : ICommand
    {
        private GameObject _panel;

        /// <summary>
        /// Установка панели для активации.
        /// </summary>
        /// <param name="game">Панель</param>
        public OpenPanelCommand(GameObject game)
        {
            _panel = game;
        }

        public void Execute()
        {
            _panel.SetActive(true);
        }
    }
}