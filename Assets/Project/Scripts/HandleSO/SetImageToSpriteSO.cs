using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[ExecuteAlways]
public class SetImageToSpriteSO : RequireSO<SpriteSO>
{
    private readonly LazyComponent<Image> _image = new();
    public Image Image => _image.Value(this);

    private SpriteSO _perviousSO;

    private void OnEnable()
    {
        UpdateImage();
        DerivedSO.OnSpriteChanged.AddListener(UpdateImage);
    }

    private void OnDisable()
    {
        DerivedSO.OnSpriteChanged.RemoveListener(UpdateImage);
    }

    protected override void Update()
    {
        base.Update();

        CheckChangesSO();
        CheckChangesSprite();
    }

    private void CheckChangesSO()
    {
        if (DerivedSO != _perviousSO) UpdateImage();
        else return;

        _perviousSO = DerivedSO;
    }

    private void CheckChangesSprite()
    {
        if (Image.sprite != DerivedSO) UpdateImage();
        else return;
    }

    private void UpdateImage(Sprite sprite)
    {
        Image.sprite = sprite;
    }

    private void UpdateImage()
    {
        if (DerivedSO == null)
        {
            Image.sprite = null;
            return;
        }

        Image.sprite = DerivedSO.Sprite;
    }
}
