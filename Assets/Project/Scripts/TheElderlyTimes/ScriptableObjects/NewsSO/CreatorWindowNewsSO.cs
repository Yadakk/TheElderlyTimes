#if UNITY_EDITOR

using UnityEditor;
using UnityEngine.Events;
using UnityEngine;

public class CreatorWindowNewsSO : EditorWindow
{
    public readonly UnityEvent<NewsSO> OnAccepted = new();

    private readonly string _themeLabel = "Theme";
    private Theme _theme;

    private readonly string _isVipLabel = "Is Vip";
    private bool _isVip;

    private void OnGUI()
    {
        _theme = (Theme)EditorGUILayout.EnumPopup(_themeLabel, _theme);
        _isVip = EditorGUILayout.Toggle(_isVipLabel, _isVip);

        if (GUILayout.Button("Generate"))
        {
            var newsSO = CreateInstance<NewsSO>();
            newsSO.Theme = _theme;
            newsSO.IsVip = _isVip;

            OnAccepted.Invoke(newsSO);
        }

        if (GUILayout.Button("Close"))
        {
            Close();
        }
    }

    public static void ShowWindow(UnityAction<NewsSO> onAccepted)
    {
        var window = CreateInstance<CreatorWindowNewsSO>();
        window.OnAccepted.AddListener(onAccepted);
        window.titleContent.text = "NewsSO creator";
        window.ShowUtility();
    }
}

#endif