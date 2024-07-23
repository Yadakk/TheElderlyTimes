using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class TweenImageFill : MonoBehaviour
{
    public RectTransform FillTransform;

    [SerializeField] private float _durationSeconds = 1f;
    public float DurationSeconds
    {
        get => _durationSeconds;
        set
        {
            _durationSeconds = value;
            FillTweener = CreateFillTweener();
        }
    }

    [SerializeField] private Ease _ease = Ease.InOutExpo;
    public Ease Ease
    {
        get => _ease;
        set
        {
            _ease = value;
            FillTweener = CreateFillTweener();
        }
    }

    [SerializeField] private Direction _fillDirection;
    public Direction FillDirection 
    {
        get => _fillDirection;
        set
        {
            _fillDirection = value;
            FillTweener = CreateFillTweener();
        }
    }

    private Tweener _fillTweener;
    public Tweener FillTweener
    {
        get
        {
            _fillTweener ??= CreateFillTweener();
            return _fillTweener;
        }
        private set => _fillTweener = value;
    }

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    public void SetFillSeconds(float seconds)
    {
        FillTweener.Goto(seconds);
    }

    private Tweener CreateFillTweener()
    {
        FillTransform.sizeDelta = GetZeroSize(FillDirection);
        return FillTransform.DOSizeDelta(FillDirectionToSize(FillDirection, 1f), DurationSeconds).SetEase(Ease).Pause();
    }

    private Vector2 GetZeroSize(Direction direction)
    {
        return direction switch
        {
            Direction.Horisontal => new(0f, RectTransform.sizeDelta.y),
            _ => new(RectTransform.sizeDelta.x, 0f),
        };
    }

    private Vector2 FillDirectionToSize(Direction direction, float fillAmount)
    {
        return direction switch
        {
            Direction.Horisontal => new(RectTransform.sizeDelta.x * fillAmount, RectTransform.sizeDelta.y),
            _ => new(RectTransform.sizeDelta.x, RectTransform.sizeDelta.y * fillAmount),
        };
    }

    public enum Direction { Horisontal, Vertical }
}