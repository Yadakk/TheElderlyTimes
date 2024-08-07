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
        string folderPath = ClickedDir.GetPath();
        string[] spriteGUIDs = AssetDatabase.FindAssets("t:Sprite", new string[] { folderPath });

        for (int i = 0; i < spriteGUIDs.Length; i++)
        {
            string spritePath = AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);

            SpriteSO spriteSO = ScriptableObject.CreateInstance<SpriteSO>();
            spriteSO.Sprite = sprite;

            AssetDatabase.CreateAsset(spriteSO, Path.Combine(folderPath, sprite.name) + ".asset");
        }
    }
}

#endif