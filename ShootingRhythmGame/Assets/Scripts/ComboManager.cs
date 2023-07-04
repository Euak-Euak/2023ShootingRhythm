using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] _SkillPanel;
    
    private KeyCode[] CmdList = { KeyCode.A, KeyCode.A, KeyCode.S, KeyCode.None, KeyCode.A, KeyCode.None, KeyCode.None, KeyCode.None }; //¿¡ÈÞ
    static public KeyCode _keyCode;
    private int _comboCnt = 0;


    void Start()
    {

    }


    void Update()
    {
        _keyCode = CmdList[_comboCnt];

        /*if (ÈÇ¶óÈÇ¶ó)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                _comboCnt++;
                Debug.Log("¹Ù³ª³ªÈÇ¶óÃã" + _comboCnt);
            }
            else if (Input.anyKeyDown) //&& ³ëÆ®³õÄ§ )
            {
                _comboCnt = 0;
                Debug.Log("¶ÊÃß»öÅ°" + _comboCnt);
            }
        }*/
    }
}