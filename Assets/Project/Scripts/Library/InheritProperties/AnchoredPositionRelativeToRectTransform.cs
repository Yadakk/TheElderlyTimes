using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchoredPositionRelativeToRectTransform : MonoBehaviour
{
    public RectTransform RelativeRectTransform;
    public Vector2 Offset;

    private readonly LazyComponent<RectTransform> _rectTransform = new();
    public RectTransform RectTransform => _rectTransform.Value(this);

    private void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        Transform oldParent = RectTransform.parent;
        RectTransform.SetParent(RelativeRectTransform);

        RectTransform.anchoredPosition = Offset;

        RectTransform.SetParent(oldParent);
    }
}
