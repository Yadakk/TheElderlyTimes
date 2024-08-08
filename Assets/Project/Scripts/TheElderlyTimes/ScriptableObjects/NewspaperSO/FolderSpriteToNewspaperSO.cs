#if UNITY_EDITOR

using UnityEditor;

public static class FolderSpriteToNewspaperSO
{
    [MenuItem("Assets/Create/ScriptableObjects/NewspaperSO/Sprites From Folder", false)]
    private static void OnMenuItemClicked()
    {
        CreatorWindowNewspaperSO.ShowWindow(CreateForEverySprite);
    }

    public static void CreateForEverySprite(NewspaperSO newsSO)
    {
        FolderSpriteToSO.CreateForEverySprite(newsSO);
    }
}

#endif