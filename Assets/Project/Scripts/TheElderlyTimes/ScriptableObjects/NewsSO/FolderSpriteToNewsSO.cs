#if UNITY_EDITOR

using UnityEditor;

public static class FolderSpriteToNewsSO
{
    [MenuItem("Assets/Create/ScriptableObjects/NewsSO/Sprites From Folder", false)]
    private static void OnMenuItemClicked()
    {
        CreatorWindowNewsSO.ShowWindow(CreateForEverySprite);
    }

    public static void CreateForEverySprite(NewsSO newsSO)
    {
        FolderSpriteToSO.CreateForEverySprite(newsSO);
    }
}

#endif