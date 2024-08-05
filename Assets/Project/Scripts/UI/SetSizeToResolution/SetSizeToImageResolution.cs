using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ImageSpriteChangedMonoEvent))]
[RequireComponent(typeof(RectTransform))]
[ExecuteAlways]
public class SetSizeToImageResolution : MonoBehaviour
{
    private readonly LazyComponent<ImageSpriteChangedMonoEvent> _monoEvent = new();
    public ImageSpriteChangedMonoEvent MonoEvent => _monoEvent.Value(this);

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    private void OnEnable()
    {
        UpdateSize();
        MonoEvent.OnSpriteChanged.AddListener(UpdateSize);
    }

    private void OnDisable() =>
        MonoEvent.OnSpriteChanged.RemoveListener(UpdateSize);

    private void UpdateSize()
    {
        Sprite sprite = MonoEvent.Image.sprite;

        if (!sprite) return;
        RectTransform.sizeDelta = sprite.rect.size;
    }

    private void UpdateSize(Sprite sprite)
    {
        if (!sprite) return;
        RectTransform.sizeDelta = sprite.rect.size;
    }
}