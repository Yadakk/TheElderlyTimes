using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LazyComponentBase<T> where T : Component
{
    private T _value;

    public T Value(Component context)
    {
        if (_value == null) _value = GetComponent(context);
        return _value;
    }

    protected abstract T GetComponent(Component context);
}
