using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
[ExecuteAlways]
public class ImageSpriteChangedMonoEvent : MonoBehaviour
{
    private readonly UnityEvent<Sprite> _onSpriteChanged = new();
    public UnityEvent<Sprite> OnSpriteChanged => _onSpriteChanged;

    private readonly LazyComponent<Image> _image = new();
    public Image Image => _image.Value(this);

    private Sprite _previousSprite;

    private void Update()
    {
        var sprite = Image.sprite;

        if (sprite == _previousSprite) return;

        OnSpriteChanged.Invoke(sprite);
        _previousSprite = sprite;
    }
}
