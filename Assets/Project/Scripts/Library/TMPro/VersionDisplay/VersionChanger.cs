#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class VersionChanger : EditorWindow
{
    public static readonly UnityEvent<string> OnVersionChanged = new();

    private static readonly string _windowLabel = "Enter a new version name: ";
    private static string _inputText;

    private void OnGUI()
    {
        _inputText = EditorGUILayout.TextField(_windowLabel, _inputText);

        if (GUILayout.Button("Accept"))
        {
            if (PlayerSettings.bundleVersion != _inputText) OnVersionChanged.Invoke(_inputText);
            PlayerSettings.bundleVersion = _inputText;
            Close();
        }

        if (GUILayout.Button("Cancel"))
        {
            Close();
        }
    }

    [MenuItem("Version/Change Version")]
    private static void MenuOption()
    {
        var window = CreateInstance<VersionChanger>();
        window.titleContent.text = "Version Changer";
        _inputText = PlayerSettings.bundleVersion;
        window.ShowUtility();
    }
}

#endif