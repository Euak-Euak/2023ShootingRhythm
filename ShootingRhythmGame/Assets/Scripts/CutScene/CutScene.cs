using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    private TypingEffect _typing;

    [SerializeField]
    private List<Sprite> _sprites;
    [SerializeField]
    private List<string> _scripts;

    [SerializeField]
    private Image _image;

    private int _index = 0;
    private void Start()
    {
        _typing = GetComponent<TypingEffect>();
        Next();
    }

    public void Next()
    {
        if (_index == _scripts.Count)
        {
            SceneLoadManager.LoadScene("SampleTitleScene");
            return;
        }

        _typing.Typing(_scripts[_index]);
        _image.sprite = _sprites[_index];

        _index++;
    }

}
