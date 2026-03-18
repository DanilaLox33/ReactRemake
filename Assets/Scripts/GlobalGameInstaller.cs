using Project.Features.Game;
using UnityEngine;
using Zenject;

public class GlobalGameInstaller : MonoInstaller
{
    [SerializeField] private AudioController _audioController;

    public override void InstallBindings()
    {
        Container.Bind<AnimationController>().FromNew().AsSingle().NonLazy();
        Container.Bind<LocalizationController>().FromNew().AsSingle().NonLazy();
        Container.Bind<AudioController>().FromComponentInNewPrefab(_audioController).AsSingle().NonLazy();
    }
}
