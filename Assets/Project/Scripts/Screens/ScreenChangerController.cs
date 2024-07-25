using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ScreenChanger;

public class ScreenChangerController : MonoBehaviour
{
    public ScreenChanger ScreenChanger;
    public Direction Direction;

    public void ChangeScreen()
    {
        ScreenChanger.ChangeScreen(Direction);
    }
}
