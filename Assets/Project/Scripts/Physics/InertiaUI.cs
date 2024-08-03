using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class InertiaUI : MonoBehaviour
{
    [Range(0f, 1f)]
    public float Friction = 0.5f;

    private readonly LazyComponentInParent<Canvas> _canvas = new();
    public Canvas Canvas => _canvas.Value(this);

    private Vector2 _velocity;
    public Vector2 Velocity { get => _velocity; set => _velocity = value; }

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    protected virtual void FixedUpdate()
    {
        RectTransform.localPosition += (Vector3)Velocity / Canvas.scaleFactor;
        Velocity = Vector2.Lerp(Velocity, Vector2.zero, Friction);
    }
}
