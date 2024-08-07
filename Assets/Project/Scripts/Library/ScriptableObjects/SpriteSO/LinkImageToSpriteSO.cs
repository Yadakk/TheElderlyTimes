using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LinkImageToSpriteSO : MonoBehaviour
{
    public bool SetSizeToResolution;

    [SerializeField] private SpriteSO _spriteSO;
    public SpriteSO SpriteSO
    {
        get => _spriteSO;
        set
        {
            _spriteSO = value;
            Image.sprite = _spriteSO.Sprite;
            if (SetSizeToResolution) Image.rectTransform.sizeDelta = _spriteSO.Sprite.rect.size;
        }
    }

    private readonly LazyComponent<Image> _image = new();
    public Image Image => _image.Value(this);
}
