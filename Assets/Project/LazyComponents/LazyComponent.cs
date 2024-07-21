using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyComponent<T> where T : Component
{
    private T _value;

    public T Value(Component context) => !_value ? _value = context.GetComponent<T>() : _value;
}