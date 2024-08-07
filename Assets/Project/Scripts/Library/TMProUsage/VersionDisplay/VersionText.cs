using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VersionText : MonoBehaviour
{
    private readonly LazyComponent<TextMeshProUGUI> _textMesh = new();
    public TextMeshProUGUI TextMesh => _textMesh.Value(this);

    private void Start()
    {
        UpdateText();
    }

    private void OnValidate()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        TextMesh.text = "Version: " + Application.version;
    }
}
