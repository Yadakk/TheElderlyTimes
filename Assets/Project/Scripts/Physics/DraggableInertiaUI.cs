using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InertiaUI))]
public class DraggableInertiaUI : Draggable
{
    public float PullForce = 0.1f;

    private readonly LazyComponent<InertiaUI> _inertiaUI = new();
    public InertiaUI InertiaUI => _inertiaUI.Value(this);

    private Vector3 _grabOffset;
    private bool _isDragging;

    public virtual void FixedUpdate()
    {
        if (!_isDragging) return;
        Vector2 direction = Input.mousePosition - RectTransform.position - _grabOffset;
        InertiaUI.Velocity += direction * PullForce;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        _grabOffset = Input.mousePosition - RectTransform.position;
        _isDragging = true;
    }

    public override void OnDrag(PointerEventData eventData) { }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        _isDragging = false;
    }
}
