using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewsSOList : GenericSOList<NewsSO>
{
    [MenuItem("Assets/Create/ScriptableObjects/News/Folder To List", false)]
    private static void OnMenuItemClicked()
    {
        var scriptableObjectList = CreateInstance<NewsSOList>();
        SOFromFolderToList.CreateSOListFromClickedFolder(scriptableObjectList);
    }
}
