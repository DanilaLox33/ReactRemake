namespace Project.Features.Command
{
    using UnityEngine.SceneManagement;
    /// <summary>
    /// Команда загрузки сцены.
    /// </summary>
    public class LoadSceneCommand : ICommand
    {
        private string _sceneName;

        /// <summary>
        /// Установка имени. 
        /// </summary>
        /// <param name="sceneName"></param>
        public LoadSceneCommand(string sceneName)
        {
            _sceneName = sceneName;
        }

        /// <summary>
        /// Загрузка сцены по имени.
        /// </summary>
        public void Execute()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
