using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TweenImageColorOnClick : MonoBehaviour, IPointerDownHandler
{
    public TweenImageColor TweenImageColor;

    private float _colorSeconds;
    public float ColorSeconds
    {
        get => _colorSeconds;
        private set
        {
            if (value < 0) _colorSeconds = 0;
            else if (value > TweenImageColor.DurationSeconds) _colorSeconds = TweenImageColor.DurationSeconds;
            else _colorSeconds = value;

            TweenImageColor.SetColorSeconds(_colorSeconds);
        }
    }

    private bool _isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        StartCoroutine(WaitForMouseReleaseRoutine());
    }

    private IEnumerator WaitForMouseReleaseRoutine()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        _isPressed = false;
    }

    private void Update()
    {
        if (_isPressed) ColorSeconds += Time.deltaTime;
        else ColorSeconds -= Time.deltaTime;
    }
}
