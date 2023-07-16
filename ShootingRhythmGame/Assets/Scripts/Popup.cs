using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    private CanvasGroup _canvas;

    private void Awake()
    {
        _canvas = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        _canvas.alpha = 1f;
        _canvas.interactable = true;
        _canvas.blocksRaycasts = true;
    }

    public void Close()
    {
        _canvas.alpha = 0f;
        _canvas.interactable = false;
        _canvas.blocksRaycasts = false;
    }
}
