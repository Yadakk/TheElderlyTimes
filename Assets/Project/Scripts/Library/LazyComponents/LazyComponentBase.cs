using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LazyComponentBase<T>
{
    private T _value;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0074:»спользовать составной оператор назначени€", Justification = "Also needs to support interfaces")]
    public T Value(Component context)
    {
        if (_value == null) _value = GetComponent(context);
        return _value;
    }

    protected abstract T GetComponent(Component context);
}
