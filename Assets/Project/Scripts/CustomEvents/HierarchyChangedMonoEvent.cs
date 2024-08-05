using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteAlways]
public class HierarchyChangedMonoEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _onHierarchyChanged = new();
    public UnityEvent OnHierarchyChanged => _onHierarchyChanged;

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
