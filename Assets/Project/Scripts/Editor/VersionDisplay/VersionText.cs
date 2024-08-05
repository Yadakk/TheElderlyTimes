using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(VersionChangedMonoEvent))]
[ExecuteAlways]
public class VersionText : MonoBehaviour
{
    private readonly LazyComponent<TextMeshProUGUI> _textMesh = new();
    public TextMeshProUGUI TextMesh => _textMesh.Value(this);

    private readonly LazyComponent<VersionChangedMonoEvent> _monoEvent = new();
    public VersionChangedMonoEvent MonoEvent => _monoEvent.Value(this);

    private void OnEnable()
    {
        UpdateText();
        MonoEvent.OnVersionChanged.AddListener(UpdateText);
    }

    private void OnDisable()
    {
        MonoEvent.OnVersionChanged.RemoveListener(UpdateText);
    }

    private void UpdateText()
    {
        TextMesh.text = "Version: " + Application.version;
    }

    private void UpdateText(string versionNumber)
    {
        TextMesh.text = "Version: " + versionNumber;
    }
}
