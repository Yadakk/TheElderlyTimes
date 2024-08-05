using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HierarchyChangedMonoEvent))]
[RequireComponent(typeof(RectTransform))]
public class InertiaUIBorder : MonoBehaviour
{
    public float PushForce = 0.1f;

    private readonly LazyComponent<HierarchyChangedMonoEvent> _hierarchyChangedEvent = new();
    public HierarchyChangedMonoEvent HierarchyChangedEvent => _hierarchyChangedEvent.Value(this);

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    private InertiaUI[] _inertias;

    private void OnEnable()
    {
        _inertias = GetDraggables();
        HierarchyChangedEvent.OnHierarchyChanged.AddListener(OnHierarchyChangedHandler);
    }

    private void OnDisable() =>
        HierarchyChangedEvent.OnHierarchyChanged.RemoveListener(OnHierarchyChangedHandler);

    private void FixedUpdate()
    {
        foreach (InertiaUI inertia in _inertias)
            AccelerateTowardsBorders(inertia);
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