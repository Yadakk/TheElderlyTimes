using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FullScreenSetting))]
public class SettingsController : MonoBehaviour
{
    private readonly LazyComponent<FullScreenSetting> _fullScreenSetting = new();
    public FullScreenSetting FullScreenSetting => _fullScreenSetting.Value(this);

    private readonly Lazy<InputAsset> _inputAsset = new();

    private void Start()
    {
        _inputAsset.Value.Settings.FullScreen.started += (context) => FullScreenSetting.FullScreen = !FullScreenSetting.FullScreen;
    }

    private void OnEnable() => _inputAsset.Value.Settings.Enable();

    private void OnDisable() => _inputAsset.Value.Settings.Disable();
}