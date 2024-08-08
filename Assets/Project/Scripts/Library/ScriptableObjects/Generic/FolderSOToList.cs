#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public static class FolderSOToList
{
    public static void CreateSOListFromClickedFolder<T>(GenericSOList<T> genericSOList) where T : ScriptableObject
    {
        string folderPath = ClickedDir.GetPath();

        string[] scriptableObjectGUIDs = AssetDatabase.FindAssets("t:" + typeof(T).Name, new string[] { folderPath });

        for (int i = 0; i < scriptableObjectGUIDs.Length; i++)
        {
            string scriptableObjectPath = AssetDatabase.GUIDToAssetPath(scriptableObjectGUIDs[i]);
            T scriptableObject = AssetDatabase.LoadAssetAtPath<T>(scriptableObjectPath);

            if (scriptableObject is not GenericSOList<T>)
                genericSOList.ScriptableObjects.Add(scriptableObject);
        }

        AssetDatabase.CreateAsset(genericSOList, Path.Combine(folderPath, typeof(T).Name + "List.asset"));
    }
}

#endif