using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] _SkillPanel;
    
    private KeyCode[] CmdList = { KeyCode.A, KeyCode.A, KeyCode.S, KeyCode.A, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None }; //����
    static public KeyCode _keyCode;
    static public int ComboCnt = 0;


    void Start()
    {
        _keyCode = KeyCode.A;
    }


    void Update()
    {
        //_keyCode = CmdList[ComboCnt];

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