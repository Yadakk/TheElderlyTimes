using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class ProjectInfo
{
    public static readonly UnityEvent<string> OnVersionChanged = new();
    private static string _version;
    public static string Version
    {
        get => _version;
        set
        {
            if (value != _version) OnVersionChanged.Invoke(value);
            _version = value;
        }
    }
}
