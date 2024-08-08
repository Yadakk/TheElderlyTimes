#if UNITY_EDITOR

using UnityEditor;
using UnityEngine.Events;
using UnityEngine;

public class CreatorWindowNewspaperSO : EditorWindow
{
    public readonly UnityEvent<NewspaperSO> OnAccepted = new();

    private readonly string _themeLabel = "Theme";
    private Theme _theme;

    private void OnGUI()
    {
        _theme = (Theme)EditorGUILayout.EnumPopup(_themeLabel, _theme);

        if (GUILayout.Button("Generate"))
        {
            var newsSO = CreateInstance<NewspaperSO>();
            newsSO.Theme = _theme;

            OnAccepted.Invoke(newsSO);
        }

        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }

    public static void ShowWindow(UnityAction<NewspaperSO> onAccepted)
    {
        var window = CreateInstance<CreatorWindowNewspaperSO>();
        window.OnAccepted.AddListener(onAccepted);
        window.titleContent.text = "NewsSO creator";
        window.ShowUtility();
    }
}

#endif