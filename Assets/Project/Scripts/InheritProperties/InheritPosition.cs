using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritPosition : MonoBehaviour
{
    public Transform TransformSource;

    private void Update()
    {
        UpdatePosition();
    }

    private void OnValidate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = TransformSource.position;
    }
}