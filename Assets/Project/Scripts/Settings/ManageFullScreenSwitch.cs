using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManageFullScreenSwitch : MonoBehaviour
{
    private int _fullScreenWidth = 0;
    private int _fullScreenHeight = 0;

    private bool _fullScreen = false;

    private void Start()
    {
        _fullScreen = Screen.fullScreen;
        SetFullScreenValues();
    }

    private void Update()
    {
        if (_fullScreen != Screen.fullScreen)
        {
            if (Screen.fullScreen)
            {
                RestoreFullScreenResolution();
            }

            _fullScreen = Screen.fullScreen;
        }
    }

    private void RestoreFullScreenResolution()
    {
        Screen.SetResolution(_fullScreenWidth, _fullScreenHeight, FullScreenMode.FullScreenWindow, new RefreshRate());
    }

    private void SetFullScreenValues()
    {
        // Set the screen width and height
        int systemWidth = Display.main.systemWidth;
        int systemHeight = Display.main.systemHeight;

        // Get a list of all supported resolutions
        Resolution[] supportedResolutions = Screen.resolutions;

        // Find the closest supported resolution to the native resolution
        Resolution closestResolution = supportedResolutions[0];
        int smallestGapInResolution = int.MaxValue;

        foreach (Resolution resolution in supportedResolutions)
        {
            int gap = Mathf.Abs(resolution.width - systemWidth) + Mathf.Abs(resolution.height - systemHeight);

            if (gap < smallestGapInResolution)
            {
                smallestGapInResolution = gap;
                closestResolution = resolution;
            }
        }

        _fullScreenWidth = closestResolution.width;
        _fullScreenHeight = closestResolution.height;
    }
}