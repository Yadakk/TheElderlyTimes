using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ScreenChanger;

public class ScreenChangerController : MonoBehaviour
{
    public ScreenChanger ScreenChanger;
    public Vector2Int Coordinates;

    public void ChangeScreen()
    {
        ScreenChanger.ChangeScreen(Coordinates);
    }
}
