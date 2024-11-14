using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class InputPanelView : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public event Action<Vector2> moved;

    public void OnDrag(PointerEventData eventData)
    {
        moved?.Invoke(eventData.delta);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moved?.Invoke(Vector2.zero);
    }
}