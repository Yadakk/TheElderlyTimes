using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewsSOList : GenericSOList<NewsSO>
{
    [MenuItem("Assets/Create/ScriptableObjects/NewsSO/Folder To List", false)]
    private static void OnMenuItemClicked()
    {
        var scriptableObjectList = CreateInstance<NewsSOList>();
        FolderSOToList.CreateSOListFromClickedFolder(scriptableObjectList);
    }
}
