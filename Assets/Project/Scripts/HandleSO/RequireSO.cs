using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RequireSO<T> : MonoBehaviour where T : ScriptableObject
{
    public T DerivedSO;

    private readonly LazyComponentInParent<IContainSO> _iContainSO = new();
    public IContainSO IContainSO => _iContainSO.Value(this);

    protected virtual void Update()
    {
        if (IContainSO == null) return;
        if (IContainSO.ScriptableObject == null)
        {
            DerivedSO = null;
            return;
        }
        if (IContainSO.ScriptableObject is not T) return;
        if (IContainSO.ScriptableObject == DerivedSO) return;

        DerivedSO = (T)IContainSO.ScriptableObject;
    }

    public void SetSO(ScriptableObject scriptableObject)
    {
        if (!scriptableObject)
        {
            DerivedSO = null;
            return;
        }

        if (scriptableObject is T derivedSO)
            DerivedSO = derivedSO;
    }
}
