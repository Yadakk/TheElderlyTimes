using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMP_LinkedTexts : MonoBehaviour
{
    public List<TextMeshProUGUI> TextsMeshes;

    [SerializeField] private string _text;
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            UpdateTextMeshes();
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        UpdateTextMeshes();
    }
#endif

    private void UpdateTextMeshes()
    {
        foreach (var textMesh in TextsMeshes)
        {
            if (!textMesh) return;
            UpdateTextMesh(textMesh);
        }
    }

    protected virtual void UpdateTextMesh(TextMeshProUGUI textMesh)
    {
        textMesh.text = Text;
    }
}