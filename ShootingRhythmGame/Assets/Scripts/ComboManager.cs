using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//현재 갖고있는 스킬만
public class HoldingCommandData
{
    public List<KeyCode> Skill = new List<KeyCode>();
}

public class ComboManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _skillPanel;

    private List<HoldingCommandData> KeyList = new List<HoldingCommandData>();
    static public List<KeyCode> NowKeyList = new List<KeyCode>();

    static public KeyCode _keyCode;
    static public int ComboCnt = 0;


    void Awake()
    {
        KeyCode[] skill_1 = { KeyCode.A, KeyCode.A, KeyCode.S, KeyCode.A, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None };
        KeyCode[] skill_2 = { KeyCode.A, KeyCode.A, KeyCode.S, KeyCode.A, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None };

        for (int i = 0; i < _skillPanel.Length; i++)
        {
            KeyList.Add(new HoldingCommandData());
        }

        foreach (KeyCode item in skill_1)
        {
            KeyList[0].Skill.Add(item);
        }

        foreach (KeyCode item in skill_2)
        {
            KeyList[1].Skill.Add(item);
        }
        //커맨드는 문지가 어떻게 잘  주겠지 


        for (int i = 0; i < 2; i++) //ㅜㅜ
        {
            NowKeyList.Add(KeyList[i].Skill[0]);
        }
    }


    void Update()
    {
        //_keyCode = CmdList[ComboCnt];

        /*if (훌라훌라)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                _comboCnt++;
                Debug.Log("바나나훌라춤" + _comboCnt);
            }
            else if (Input.anyKeyDown) //&& 노트놓침 )
            {
                _comboCnt = 0;
                Debug.Log("똘추색키" + _comboCnt);
            }
        }*/
    }
}