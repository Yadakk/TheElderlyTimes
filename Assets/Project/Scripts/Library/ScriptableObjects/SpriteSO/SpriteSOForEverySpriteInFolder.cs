#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class SpriteSOForEverySpriteInFolder
{
    [MenuItem("Assets/Create/ScriptableObjects/Sprite/For Every Sprite In Folder", false)]
    private static void OnMenuItemClicked()
    {
        SpriteSO spriteSO = ScriptableObject.CreateInstance<SpriteSO>();
        CreateForEverySprite(spriteSO);
    }

    public static void CreateForEverySprite(SpriteSO spriteSO)
    {
        string folderPath = ClickedDir.GetPath();

        Sprite[] sprites = AssetLoader.FromFolder<Sprite>(folderPath, out string[] spritePaths);

        for (int i = 0; i < sprites.Length; i++)
        {
            SpriteSO newSpriteSO = spriteSO.Clone();
            newSpriteSO.Sprite = sprites[i];

            string targetFolder = Path.GetDirectoryName(spritePaths[i]);
            string fileNameSO = newSpriteSO.GetType().Name + sprites[i].name + ".asset";
            AssetDatabase.CreateAsset(newSpriteSO, Path.Combine(targetFolder, fileNameSO));
        }
    }
}

#endif