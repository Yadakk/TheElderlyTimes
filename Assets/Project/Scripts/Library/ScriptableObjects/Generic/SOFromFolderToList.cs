#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public static class SOFromFolderToList
{
    public static void CreateSOListFromClickedFolder<T>(GenericSOList<T> genericSOList) where T : ScriptableObject
    {
        string folderPath = ClickedDir.GetPath();

        T[] scriptableObjects = AssetLoader.FromFolder<T>(folderPath);
        genericSOList.ScriptableObjects = new T[scriptableObjects.Length];

        for (int i = 0; i < scriptableObjects.Length; i++)
        {
            if (scriptableObjects[i] is not GenericSOList<T>)
                genericSOList.ScriptableObjects[i] = scriptableObjects[i];
        }

        AssetDatabase.CreateAsset(genericSOList, Path.Combine(folderPath, typeof(T).Name + "List.asset"));
    }
}

#endif