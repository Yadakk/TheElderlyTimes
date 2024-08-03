using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectTransformBorderExtension
{
    public static Vector2 GetBorderDirection(this RectTransform rectTransform, RectTransform borderRectTransform)
    {
        Vector2 pos = rectTransform.localPosition;

        Vector2 minPosition = borderRectTransform.rect.min - rectTransform.rect.min;
        Vector2 maxPosition = borderRectTransform.rect.max - rectTransform.rect.max;

        Vector2 borderPoint = new(
            Mathf.Clamp(pos.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(pos.y, minPosition.y, maxPosition.y));
        return borderPoint - pos;
    }
}