using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class AbsoluteRelativePathUtility
{
    public static string AbsoluteToRelativePath(string path)
    {
        if (!path.StartsWith(Application.dataPath)) return path;
        path = "Assets" + path[Application.dataPath.Length..];
        return path;
    }

    public static string RelativeToAbsolutePath(string path)
    {
        if (!path.StartsWith("Assets")) return path;
        path = Path.GetDirectoryName(Path.GetFullPath(Path.Combine(Application.dataPath, @"../")) + path);
        return path;
    }
}
