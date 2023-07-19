using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightUpSkillCmdPanel : MonoBehaviour
{
    public int PanelSkillNum;
    public int PanelCmdNum;
    
    private Image _img;
    private Sprite _original;
    [SerializeField] private Sprite _rightUp;

    void Start()
    {
        _img = GetComponent<Image>();
        _original = _img.sprite;
    }


    private void Update()
    {
        if (CommandManager.ComboList[PanelSkillNum] == PanelCmdNum)
        {
            _img.sprite = _rightUp;
        }
        else _img.sprite= _original;
    }
}
