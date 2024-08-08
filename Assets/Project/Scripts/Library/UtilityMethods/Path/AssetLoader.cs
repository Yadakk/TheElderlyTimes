#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class AssetLoader
{
    public static T[] FromFolder<T>(string path) where T : Object
    {
        string[] objGUIDs = AssetDatabase.FindAssets("t:" + typeof(T).Name, new string[] { path });

        T[] objs = new T[objGUIDs.Length];

        for (int i = 0; i < objGUIDs.Length; i++)
        {
            string objPath = AssetDatabase.GUIDToAssetPath(objGUIDs[i]);
            objs[i] = AssetDatabase.LoadAssetAtPath<T>(objPath);
        }

        return objs;
    }

    public static T[] FromFolder<T>(string path, out string[] objPaths) where T : Object
    {
        string[] objGUIDs = AssetDatabase.FindAssets("t:" + typeof(T).Name, new string[] { path });

        T[] objs = new T[objGUIDs.Length];
        objPaths = new string[objGUIDs.Length];

        for (int i = 0; i < objGUIDs.Length; i++)
        {
            objPaths[i] = AssetDatabase.GUIDToAssetPath(objGUIDs[i]);
            objs[i] = AssetDatabase.LoadAssetAtPath<T>(objPaths[i]);
        }

        return objs;
    }
}

#endif