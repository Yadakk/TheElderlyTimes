using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HierarchyChangedEvent : MonoBehaviour
{
    public UnityEvent OnHierarchyChanged;

    private int _childCount;

    private void Update()
    {
        if(CheckForChanges()) OnHierarchyChanged.Invoke();
    }

    private bool CheckForChanges()
    {
        if (_childCount == transform.hierarchyCount) return false;
        _childCount = transform.hierarchyCount;
        return true;
    }
}
