using UnityEngine;

namespace Project.Features.Command
{
    /// <summary>
    /// Кнопка загрузки сцены.
    /// </summary>
    public class LoadSceneButton : ConcreteButton<LoadSceneCommand>
    {
        [SerializeField] private string _sceneName = string.Empty;
        protected override void InitButton()
        {
            command = new LoadSceneCommand(_sceneName);
        }
    }
}