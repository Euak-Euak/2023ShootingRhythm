using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] _SkillPanel;
    
    private KeyCode[] CmdList = { KeyCode.A, KeyCode.A, KeyCode.S, KeyCode.None, KeyCode.A, KeyCode.None, KeyCode.None, KeyCode.None }; //����
    static public KeyCode _keyCode;
    private int _comboCnt = 0;


    void Start()
    {

    }


    void Update()
    {
        _keyCode = CmdList[_comboCnt];

        /*if (�Ƕ��Ƕ�)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                _comboCnt++;
                Debug.Log("�ٳ����Ƕ���" + _comboCnt);
            }
            else if (Input.anyKeyDown) //&& ��Ʈ��ħ )
            {
                _comboCnt = 0;
                Debug.Log("���߻�Ű" + _comboCnt);
            }
        }*/
    }
}