#if UNITY_EDITOR

using UnityEditor;

public static class NewsSOForEverySpriteInFolder
{
    [MenuItem("Assets/Create/ScriptableObjects/News/For Every Sprite In Folder", false)]
    private static void OnMenuItemClicked()
    {
        NewsSOCreatorWindow.ShowWindow(CreateForEverySprite);
    }

    public static void CreateForEverySprite(NewsSO newsSO)
    {
        SpriteSOForEverySpriteInFolder.CreateForEverySprite(newsSO);
    }
}

#endif