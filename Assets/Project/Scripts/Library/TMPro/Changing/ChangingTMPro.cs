using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ChangingTMPro : MonoBehaviour
{
    public float FrameDurationSeconds = 0.5f;
    public List<string> StringFrames;

    private int _currentFrame;
    public int CurrentFrame
    {
        get => _currentFrame;
        private set
        {
            _currentFrame = value;
            if (_currentFrame >= StringFrames.Count) _currentFrame = 0;
        }
    }

    private readonly LazyComponent<TextMeshProUGUI> _textMesh = new();
    public TextMeshProUGUI TextMesh => _textMesh.Value(this);

    private void Start()
    {
        StartCoroutine(CycleTextRoutine());
    }

    private IEnumerator CycleTextRoutine()
    {
        while (true)
        {
            TextMesh.text = StringFrames[CurrentFrame];
            yield return new WaitForSeconds(FrameDurationSeconds);
            CurrentFrame++;
        }
    }
}
