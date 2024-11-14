using System;
using UnityEngine;

public class TouchInputSystem : IDirectionInputSystem
{
    private InputPanelView _view;
    private bool _isActive = true;

    public event Action<Vector2> moved;

    public TouchInputSystem(InputPanelView view)
    {
        _view = view;
        _view.moved += InputMoved;
    }

    ~TouchInputSystem()
    {
        _view.moved -= InputMoved;
    }

    private void InputMoved(Vector2 movedVector)
    {
        if (_isActive == true)
        {
            moved.Invoke(new Vector2(movedVector.x, 0f).normalized);
        }
    }

    public void SetActive(bool state)
    {
        _isActive = state;
    }
}