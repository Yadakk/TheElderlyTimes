using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[ExecuteAlways]
public class ImageSpriteChangedMonoEvent : Image
{
    private readonly UnityEvent<Sprite> _onSpriteChanged = new();
    public UnityEvent<Sprite> OnSpriteChanged => _onSpriteChanged;

    private Sprite _previousSprite;

    private void Update()
    {
        if (sprite != _previousSprite) OnSpriteChanged.Invoke(sprite);
        else return;
        _previousSprite = sprite;
    }
}
