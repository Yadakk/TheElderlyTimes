using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[ExecuteInEditMode]
public class VersionText : MonoBehaviour
{
    private readonly LazyComponent<TextMeshProUGUI> _textMesh = new();
    public TextMeshProUGUI TextMesh => _textMesh.Value(this);

    private void Start()
    {
        UpdateText(ProjectInfo.Version);
    }

#if UNITY_EDITOR
    private void OnEnable()
    {

        ProjectInfo.OnVersionChanged.AddListener(UpdateText);
    }

    private void OnDisable()
    {

        ProjectInfo.OnVersionChanged.RemoveListener(UpdateText);
    }
#endif

    private void UpdateText(string versionNumber)
    {
        TextMesh.text = "Version: " + versionNumber;
    }
}
