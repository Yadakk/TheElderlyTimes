using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ImageSpriteChangedMonoEvent))]
[RequireComponent(typeof(RectTransform))]
[ExecuteAlways]
public class SetSizeToResolution : MonoBehaviour
{
    private readonly LazyComponent<ImageSpriteChangedMonoEvent> _image = new();
    public ImageSpriteChangedMonoEvent Image => _image.Value(this);

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    private void OnEnable()
    {
        UpdateSize();
        Image.OnSpriteChanged.AddListener(UpdateSize);
    }

    private void OnDisable() =>
        Image.OnSpriteChanged.RemoveListener(UpdateSize);

    private void UpdateSize()
    {
        Sprite sprite = Image.sprite;

        if (!sprite) return;
        RectTransform.sizeDelta = sprite.rect.size;
    }

    private void UpdateSize(Sprite sprite)
    {
        if (!sprite) return;
        RectTransform.sizeDelta = sprite.rect.size;
    }
}