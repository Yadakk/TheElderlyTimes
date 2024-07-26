using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ScreenChanger : MonoBehaviour
{
    public float TransitionDurationSeconds;
    public Ease Ease;

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    public void ChangeScreen(Vector2Int coordinates)
    {
        RectTransform.DOLocalMove(RectTransform.rect.size * -coordinates, TransitionDurationSeconds).SetEase(Ease);
    }
}
