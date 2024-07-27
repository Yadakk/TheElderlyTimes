using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenChangerController : MonoBehaviour
{
    public ScreenChanger ScreenChanger;
    public Vector2Int Coordinates;
    public UnityEvent OnChangedScreen;

    public void ChangeScreen()
    {
        ScreenChanger.ChangeScreen(Coordinates, () => OnChangedScreen.Invoke());
    }
}
