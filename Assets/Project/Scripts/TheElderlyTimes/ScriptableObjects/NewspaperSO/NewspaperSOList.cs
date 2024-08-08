using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewspaperSOList : GenericSOList<NewspaperSO>
{
    [MenuItem("Assets/Create/ScriptableObjects/Newspaper/Folder To List", false)]
    private static void OnMenuItemClicked()
    {
        var scriptableObjectList = CreateInstance<NewspaperSOList>();
        SOFromFolderToList.CreateSOListFromClickedFolder(scriptableObjectList);
    }
}
