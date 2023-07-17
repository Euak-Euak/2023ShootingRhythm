using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Typing(string text)
    {
        StopAllCoroutines();
        StartCoroutine(TypingCoroutine(text));
    }

    private IEnumerator TypingCoroutine(string text)
    {
        _text.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            _text.text += text[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
