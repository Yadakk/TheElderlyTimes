using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenImageColor : MonoBehaviour
{
    [SerializeField] private Ease _ease = Ease.InOutExpo;
    public Ease Ease
    {
        get => _ease;
        set
        {
            _ease = value;
            ColorTweener = CreateColorTweener();
        }
    }

    [SerializeField] private Color _endColor = Color.white;
    public Color EndColor
    {
        get => _endColor;
        set
        {
            _endColor = value;
            ColorTweener = CreateColorTweener();
        }
    }

    [SerializeField] private float _durationSeconds = 1f;
    public float DurationSeconds
    {
        get => _durationSeconds;
        set
        {
            _durationSeconds = value;
            ColorTweener = CreateColorTweener();
        }
    }

    private Color _defaultColor;
    public Color DefaultColor { get => _defaultColor; set => _defaultColor = value; }

    private Tweener _colorTweener;
    public Tweener ColorTweener
    {
        get
        {
            _colorTweener ??= CreateColorTweener();
            return _colorTweener;
        }
        private set => _colorTweener = value;
    }

    private readonly LazyComponent<Image> _image = new();
    public Image Image => _image.Value(this);

    private void Awake()
    {
        DefaultColor = Image.color;
    }

    private Tweener CreateColorTweener()
    {
        Image.color = DefaultColor;
        return Image.DOColor(EndColor, DurationSeconds).SetEase(Ease).Pause();
    }

    public void SetColorSeconds(float seconds)
    {
        ColorTweener.Goto(seconds);
    }
}
