using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private InputActionAsset _asset;
    
    public override void InstallBindings()
    { 
        Container.BindInstance(_asset).AsSingle();
        
        Container.Bind<InputGameSystem>().AsSingle().NonLazy();
        Container.Bind<GameInput>().AsSingle();
    }
}