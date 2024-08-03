using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Range(0f, 1f)]
    public float AlphaInDrag = 0.4f;

    private readonly LazyComponentInParent<Canvas> _canvas = new();
    public Canvas Canvas => _canvas.Value(this);

    private readonly LazyComponent<CanvasGroup> _canvasGroup = new();
    public CanvasGroup CanvasGroup => _canvasGroup.Value(this);

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        CanvasGroup.alpha = AlphaInDrag;
        CanvasGroup.blocksRaycasts = false;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        CanvasGroup.alpha = 1f;
        CanvasGroup.blocksRaycasts = true;
    }
}