using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainSO : MonoBehaviour, IContainSO
{
    [SerializeField] private ScriptableObject _scriptableObject;
    ScriptableObject IContainSO.ScriptableObject 
    {
        get => _scriptableObject; 
        set => _scriptableObject = value; 
    }
}
