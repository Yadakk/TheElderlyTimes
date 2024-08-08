using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public abstract class GenericSOList<T> : ScriptableObject
{
    public List<ScriptableObject> ScriptableObjects = new();
}