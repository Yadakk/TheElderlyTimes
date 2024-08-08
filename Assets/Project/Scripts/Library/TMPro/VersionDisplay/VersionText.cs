using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[ExecuteAlways]
public class VersionText : MonoBehaviour
{
    private readonly LazyComponent<TextMeshProUGUI> _textMesh = new();
    public TextMeshProUGUI TextMesh => _textMesh.Value(this);

#if UNITY_EDITOR

    private void OnEnable()
    {
        UpdateText();
        VersionChanger.OnVersionChanged.AddListener(UpdateText);
    }

    private void OnDisable()
    {
        VersionChanger.OnVersionChanged.RemoveListener(UpdateText);
    }

#else

    private void Start()
    {
        UpdateText();
    }

#endif

    private void UpdateText()
    {
        TextMesh.text = "Version: " + Application.version;
    }

    private void UpdateText(string version)
    {
        TextMesh.text = "Version: " + version;
    }
}
