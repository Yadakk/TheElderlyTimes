#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class SpriteToSO
{
    [MenuItem("Assets/Create/ScriptableObjects/SpriteSO/Sprites From Folder", false)]
    private static void CreateSpritesFromFolder()
    {
        string folderPath = GetClickedDirPath();
        string[] spriteGUIDs = AssetDatabase.FindAssets("t:Sprite", new string[] { folderPath });

        for (int i = 0; i < spriteGUIDs.Length; i++)
        {
            string spritePath = AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);

            SpriteSO spriteSO = ScriptableObject.CreateInstance<SpriteSO>();
            spriteSO.Sprite = sprite;

            AssetDatabase.CreateAsset(spriteSO, folderPath + "/" + sprite.name + ".asset");
        }
    }

    private static string GetClickedDirPath()
    {
        string clickedAssetGuid = Selection.assetGUIDs[0];
        string clickedPath = AssetDatabase.GUIDToAssetPath(clickedAssetGuid);

        FileAttributes attr = File.GetAttributes(clickedPath);
        return attr.HasFlag(FileAttributes.Directory) ? clickedPath : Path.GetDirectoryName(clickedPath);
    }

    private static string GetClickedDirFullPath()
    {
        string clickedAssetGuid = Selection.assetGUIDs[0];
        string clickedPath = AssetDatabase.GUIDToAssetPath(clickedAssetGuid);
        string clickedPathFull = Path.Combine(Directory.GetCurrentDirectory(), clickedPath);

        FileAttributes attr = File.GetAttributes(clickedPathFull);
        return attr.HasFlag(FileAttributes.Directory) ? clickedPathFull : Path.GetDirectoryName(clickedPathFull);
    }
}

#endif