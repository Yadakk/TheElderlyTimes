using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class VersionChangedMonoEvent : MonoBehaviour
{
    private readonly UnityEvent<string> _onVersionChanged = new();
    public UnityEvent<string> OnVersionChanged => _onVersionChanged;

    private string _previousVersion;

#if UNITY_EDITOR
    private void Update()
    {
        if (CheckForChanges(out string version)) 
            OnVersionChanged.Invoke(version);
    }

    private bool CheckForChanges(out string version)
    {
        version = UnityEditor.PlayerSettings.bundleVersion;

        if (version == _previousVersion) return false;
        _previousVersion = version;
        return true;
    }
#endif
}
