using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhysicsBorder
{
    public RectTransform RectTransform;
    public float PushForce = 0.1f;

    public void KeepInsideBorders(InertiaUI inertiaUI)
    {
        Vector2 direction = GetDirectionToKeepInBorder(inertiaUI.RectTransform);
        inertiaUI.Velocity += direction * PushForce;
    }

    public Vector2 GetDirectionToKeepInBorder(RectTransform rectTransform)
    {
        Vector2 pos = rectTransform.localPosition;

        Vector2 minPosition = RectTransform.rect.min - rectTransform.rect.min;
        Vector2 maxPosition = RectTransform.rect.max - rectTransform.rect.max;

        Vector2 borderPoint = new(
            Mathf.Clamp(pos.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(pos.y, minPosition.y, maxPosition.y));
        return borderPoint - pos;
    }
}
