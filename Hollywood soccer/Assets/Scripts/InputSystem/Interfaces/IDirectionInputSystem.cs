using UnityEngine;
using System;

public interface IDirectionInputSystem
{
    event Action<Vector2> moved;

    void SetActive(bool state);
}