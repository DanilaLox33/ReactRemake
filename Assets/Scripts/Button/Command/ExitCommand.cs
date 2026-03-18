using UnityEngine;
namespace Project.Features.Command
{
    public class ExitCommand : ICommand
    {
        /// <summary>
        /// Закрывает игру.
        /// </summary>
        public void Execute()
        {
            Application.Quit();
        }
    }
}