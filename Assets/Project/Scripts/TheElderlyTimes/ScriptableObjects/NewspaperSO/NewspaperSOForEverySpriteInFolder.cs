#if UNITY_EDITOR

using UnityEditor;

public static class NewspaperSOForEverySpriteInFolder
{
    [MenuItem("Assets/Create/ScriptableObjects/Newspaper/For Every Sprite In Folder", false)]
    private static void OnMenuItemClicked()
    {
        NewspaperSOCreatorWindow.ShowWindow(CreateForEverySprite);
    }

    public static void CreateForEverySprite(NewspaperSO newsSO)
    {
        SpriteSOForEverySpriteInFolder.CreateForEverySprite(newsSO);
    }
}

#endif