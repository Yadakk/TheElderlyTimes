using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSetting : MonoBehaviour
{
    private bool _fullScreen;
    public bool FullScreen
    {
        get => _fullScreen;
        set
        {
            _fullScreen = value;
            SetFullScreen(_fullScreen);
        }
    }

    private void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
}