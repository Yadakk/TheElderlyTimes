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
        SpriteSO spriteSO = ScriptableObject.CreateInstance<SpriteSO>();
        CreateForEverySprite(spriteSO);
    }

    public static void CreateForEverySprite(SpriteSO spriteSO)
    {
        string folderPath = ClickedDir.GetPath();
        string[] spriteGUIDs = AssetDatabase.FindAssets("t:Sprite", new string[] { folderPath });

        for (int i = 0; i < spriteGUIDs.Length; i++)
        {
            string spritePath = AssetDatabase.GUIDToAssetPath(spriteGUIDs[i]);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);

            SpriteSO newSpriteSO = spriteSO.Clone();
            newSpriteSO.Sprite = sprite;

            string targetFolder = Path.GetDirectoryName(spritePath);
            string fileNameSO = newSpriteSO.GetType().Name + " " + sprite.name + ".asset";
            AssetDatabase.CreateAsset(newSpriteSO, Path.Combine(targetFolder, fileNameSO));
        }
    }
}

#endif