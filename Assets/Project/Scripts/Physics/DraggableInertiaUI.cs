using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableInertiaUI : Draggable
{
    [Range(0f, 1f)]
    public float Friction = 0.5f;

    private Vector2 _velocity;

    protected virtual void FixedUpdate()
    {
        RectTransform.anchoredPosition += _velocity;
        _velocity = Vector2.Lerp(_velocity, Vector2.zero, Friction);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        _velocity = Vector2.zero;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        _velocity = eventData.delta / Canvas.scaleFactor;
    }
}
