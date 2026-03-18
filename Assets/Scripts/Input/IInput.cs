using System;
using UnityEngine.InputSystem;

public interface IInput
{
    public void OnEnable();
    public void OnDisable();
}

public class GameInput : IInput
{
    private InputActionAsset _asset;
    private InputActionMap _actionMap;
    
    public GameInput(InputActionAsset asset)
    {
        _asset = asset;
        _actionMap= _asset.FindActionMap("GameBind");
        OnEnable();
    }

    public void SubClick(Action<InputAction.CallbackContext> del)
    {
        _actionMap.FindAction("LeftClick").started += del;
    }
    
    public void UnSubClick(Action<InputAction.CallbackContext> del)
    {
        _actionMap.FindAction("LeftClick").started -= del;
    }

    public void SubSkip(Action<InputAction.CallbackContext> del)
    {
        _actionMap.FindAction("Skip").performed += del;
    }

    public void UnSubSkip(Action<InputAction.CallbackContext> del)
    {
        _actionMap.FindAction("Skip").performed -= del;
    }

    public void SubStopSkip(Action<InputAction.CallbackContext> del)
    {
        _actionMap.FindAction("Skip").canceled += del;
    }
    
    public void UnSubStopSkip(Action<InputAction.CallbackContext> del)
    {
        _actionMap.FindAction("Skip").canceled -= del;
    }

    public void OnEnable()
    {
        _actionMap.Enable();
    }

    public void OnDisable()
    {
        _actionMap.Disable();
    }
}