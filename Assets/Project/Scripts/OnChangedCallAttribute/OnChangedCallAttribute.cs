using System.Linq;
using UnityEngine;

public class OnChangedCallAttribute : PropertyAttribute
{
    public string MethodName;

    public OnChangedCallAttribute(string methodNameNoArguments)
    {
        MethodName = methodNameNoArguments;
    }
}