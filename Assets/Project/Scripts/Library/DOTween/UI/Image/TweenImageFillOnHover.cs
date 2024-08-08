using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TweenImageFill))]
public class TweenImageFillOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TweenImageFill TweenImageFill;

    private float _fillSeconds;
    public float FillSeconds
    {
        get => _fillSeconds;
        private set
        {
            if (value < 0) _fillSeconds = 0;
            else if (value > TweenImageFill.DurationSeconds) _fillSeconds = TweenImageFill.DurationSeconds;
            else _fillSeconds = value;

            TweenImageFill.SetFillSeconds(_fillSeconds);
        }
    }

    private bool _isPointerInside;

    private void Update()
    {
        if (_isPointerInside) FillSeconds += Time.deltaTime;
        else FillSeconds -= Time.deltaTime;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPointerInside = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPointerInside = true;
        
    }
}