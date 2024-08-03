using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HierarchyChangedEvent))]
[RequireComponent(typeof(RectTransform))]
public class InertiaUIBorder : MonoBehaviour
{
    public float PushForce = 0.1f;

    private readonly LazyComponent<HierarchyChangedEvent> _hierarchyChangedEvent = new();
    public HierarchyChangedEvent HierarchyChangedEvent => _hierarchyChangedEvent.Value(this);

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    private InertiaUI[] _inertias;

    private void Start()
    {
        _inertias = GetDraggables();
        HierarchyChangedEvent.OnHierarchyChanged.AddListener(OnHierarchyChangedHandler);
    }

    private void FixedUpdate()
    {
        foreach (var inertia in _inertias)
        {
            AccelerateTowardsBorders(inertia);
        }
    }

    private InertiaUI[] GetDraggables()
    {
        return transform.GetComponentsInChildren<InertiaUI>();
    }

    private void OnHierarchyChangedHandler()
    {
        _inertias = GetDraggables();
    }

    private void AccelerateTowardsBorders(InertiaUI inertia)
    {
        Vector2 direction = inertia.RectTransform.GetBorderDirection(RectTransform);
        inertia.Velocity += direction * PushForce;
    }
}