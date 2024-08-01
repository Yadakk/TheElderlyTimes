using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[ExecuteInEditMode]
public class VersionText : MonoBehaviour
{
    private readonly LazyComponent<TextMeshProUGUI> _textMesh = new();
    public TextMeshProUGUI TextMesh => _textMesh.Value(this);

    private string _currentVersion;

    private void Update()
    {
        if (PlayerSettings.bundleVersion != _currentVersion)
            TextMesh.text = "Version: " + PlayerSettings.bundleVersion;
        _currentVersion = PlayerSettings.bundleVersion;
    }
}
