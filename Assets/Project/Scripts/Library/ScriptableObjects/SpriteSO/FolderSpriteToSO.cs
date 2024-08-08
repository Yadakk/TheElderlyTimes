#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class FolderSpriteToSO
{
    [MenuItem("Assets/Create/ScriptableObjects/SpriteSO/Sprites From Folder", false)]
    private static void OnMenuItemClicked()
    {
        CreateSpritesFromFolder<SpriteSO>();
    }

    private static void CreateSpritesFromFolder<T>() where T : SpriteSO
    {
        string folderPath = ClickedDir.GetPath();
        string[] spriteGUIDs = AssetDatabase.FindAssets("t:Sprite", new string[] { folderPath });

        for (int i = 0; i < spriteGUIDs.Length; i++)
        {
            string spritePath = AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
            T spriteSO = ScriptableObject.CreateInstance<T>();
            spriteSO.Sprite = sprite;
            AssetDatabase.CreateAsset(spriteSO, Path.Combine(Path.GetDirectoryName(spritePath), typeof(T) + " " + sprite.name) + ".asset");
        }
    }
}

#endif