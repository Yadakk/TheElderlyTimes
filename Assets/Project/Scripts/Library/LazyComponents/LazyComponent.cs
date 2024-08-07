using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyComponent<T> : LazyComponentBase<T> where T : Component
{
    protected override T GetComponent(Component context)
    {
        return context.GetComponent<T>();
    }
}