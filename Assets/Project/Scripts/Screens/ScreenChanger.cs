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

    private bool _inTransition;

    public void ChangeScreen(Direction direction)
    {
        if (_inTransition) return;
        _inTransition = true;
        RectTransform.DOLocalMove(RectTransform.rect.size * -DirectionToVector2(direction), TransitionDurationSeconds).SetEase(Ease).OnComplete(() => _inTransition = false);
    }

    private Vector2 DirectionToVector2(Direction direction)
    {
        return direction switch
        {
            Direction.Right => new(1f, 0f),
            Direction.Down => new(0f, -1f),
            Direction.Left => new(-1f, 0f),
            _ => new(0f, 1f),
        };
    }

    public enum Direction { Right, Down, Left, Up }
}
