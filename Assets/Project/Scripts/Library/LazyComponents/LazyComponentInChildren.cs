using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyComponentInChildren<T> : LazyComponentBase<T>
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("TypeSafety", "UNT0014:Invalid type for call to GetComponent", Justification = "Also needs to support interfaces")]
    protected override T GetComponent(Component context)
    {
        return context.GetComponentInChildren<T>();
    }
}
