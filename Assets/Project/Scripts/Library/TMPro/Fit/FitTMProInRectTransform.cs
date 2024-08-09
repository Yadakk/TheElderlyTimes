using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[ExecuteAlways]
public class FitTMProInRectTransform : MonoBehaviour
{
    public RectTransform Box;
    public Vector2 MinSize;

    private readonly LazyComponent<TextMeshProUGUI> _textMesh = new();
    public TextMeshProUGUI TextMesh => _textMesh.Value(this);

    private string _previousText;

    private void Update()
    {
        if (TextMesh.text == _previousText) return;
        UpdateSize();
        _previousText = TextMesh.text;
    }

    public void UpdateSize()
    {
        if (!Box) return;

        Vector2 boxSize = new(Mathf.Clamp(TextMesh.preferredWidth, MinSize.x, float.MaxValue),
                              Mathf.Clamp(TextMesh.preferredHeight, MinSize.y, float.MaxValue));
        Box.sizeDelta = boxSize;
    }
}
