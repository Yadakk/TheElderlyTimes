using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LinkedTMPros : MonoBehaviour
{
    public List<TextMeshProUGUI> TextMeshes;

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

    private void OnValidate()
    {
        UpdateTextMeshes();
    }

    private void UpdateTextMesh(TextMeshProUGUI textMesh)
    {
        textMesh.text = Text;
    }

    private void UpdateTextMeshes()
    {
        foreach (var textMesh in TextMeshes)
        {
            if (!textMesh) return;
            UpdateTextMesh(textMesh);
        }
    }
}