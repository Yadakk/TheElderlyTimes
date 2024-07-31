using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenChangerController : MonoBehaviour
{
    public Vector2Int CoordinateChange;
    public UnityEvent OnChangedScreen;

    private readonly LazyComponentInParent<ScreenChanger> _screenChanger = new();
    public ScreenChanger ScreenChanger => _screenChanger.Value(this);

    public void ChangeScreen()
    {
        ScreenChanger.ChangeScreen(CoordinateChange, () => OnChangedScreen.Invoke());
    }
}
