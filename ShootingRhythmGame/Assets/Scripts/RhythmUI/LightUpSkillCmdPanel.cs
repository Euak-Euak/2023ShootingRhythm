using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightUpSkillCmdPanel : MonoBehaviour
{
    public int PanelSkillNum;
    public int PanelCmdNum;

    private Image Img;
    private Color _rightDownColor;


    void Start()
    {
        Img = GetComponent<Image>();
        _rightDownColor = Img.color;
    }


    private void Update()
    {
        if (CommandManager.ComboList[PanelSkillNum] == PanelCmdNum)
        {
            Img.color = Color.white;
        }
        else Img.color = _rightDownColor;
    }

    /*
    public void OnLigth(bool lightup)
    {
        if (lightup)
        {
            Img.color = Color.white;
        }
        else Img.color = _rightDownColor;
    }*/
}
