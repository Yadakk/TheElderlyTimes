using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New SpriteSO", menuName = "ScriptableObjects/SpriteSO/SO", order = 281)]
public class SpriteSO : ScriptableObject
{
    public Sprite Sprite;
    private Sprite _previousSprite;

    private readonly UnityEvent<Sprite> _onSpriteChanged = new();
    public UnityEvent<Sprite> OnSpriteChanged => _onSpriteChanged;

    private void OnValidate()
    {
        if (Sprite == _previousSprite) return;

        _onSpriteChanged.Invoke(Sprite);
        _previousSprite = Sprite;
    }
}