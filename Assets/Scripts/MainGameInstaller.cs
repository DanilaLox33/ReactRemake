using Project.Features.Person;
using UnityEngine;
using Zenject;

namespace Project.Features.DialogSystem
{
    public class MainGameInstaller : MonoInstaller
    {
        [SerializeField] private DialogController _dialogController;
        [SerializeField] private PersonController _personController;
        [SerializeField] private GameController _gameController;
        public override void InstallBindings()
        {
            Container.Bind<DialogController>().FromInstance(_dialogController).AsSingle();
            Container.Bind<PersonController>().FromInstance(_personController).AsSingle();
            Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
        }
    }
}