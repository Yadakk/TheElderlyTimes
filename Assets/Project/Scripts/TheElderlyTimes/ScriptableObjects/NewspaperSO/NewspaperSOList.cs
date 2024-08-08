using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewspaperSOList : GenericSOList<NewspaperSO>
{
    [MenuItem("Assets/Create/ScriptableObjects/NewspaperSO/Folder To List", false)]
    private static void OnMenuItemClicked()
    {
        var scriptableObjectList = CreateInstance<NewspaperSOList>();
        FolderSOToList.CreateSOListFromClickedFolder(scriptableObjectList);
    }
}
