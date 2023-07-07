using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//현재 갖고있는 스킬만
public class HoldingCommandData
{
    public List<KeyCode> Skill = new List<KeyCode>();
}


public class ComboManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _skillPanels;
    private List<Text> _commandTexts = new List<Text>(); ///////

    static public List<HoldingCommandData> KeyList = new List<HoldingCommandData>();
    static public List<KeyCode> NowKeyList = new List<KeyCode>();
    static public List<int> ComboList = new List<int>();

    static public KeyCode _keyCode;


    void Awake()
    {
        KeyCode[] skill_1 = { KeyCode.None, KeyCode.A, KeyCode.S, KeyCode.None, KeyCode.A, KeyCode.None};
        KeyCode[] skill_2 = { KeyCode.A, KeyCode.A, KeyCode.A, KeyCode.A, KeyCode.D, KeyCode.D, KeyCode.D, KeyCode.D };
        //커맨드는 문지가 어떻게 잘  주겠지


        for (int i = 0; i < _skillPanels.Length; i++)
        {
            KeyList.Add(new HoldingCommandData());
            ComboList.Add(0);
        }

        ///////////////////
        foreach (KeyCode item in skill_1)
        {
            KeyList[0].Skill.Add(item);
        }

        foreach (KeyCode item in skill_2)
        {
            KeyList[1].Skill.Add(item);
        }
        ////////////////////

        /////////////////
        for (int i = 0; i < _skillPanels.Length; i++)
        {
            for (int j = 0; j < KeyList[i].Skill.Count; j++)
            {
                _commandTexts.Add(null);
            }
        }
        /////////////////

        for (int i = 0; i < _skillPanels.Length; i++)
        {
            MakeSkillPanel(i);

            NowKeyList.Add(KeyList[i].Skill[0]);
        }
    }


    private void Start()
    {

    }


    void Update()
    {
        for (int i = 0; i < _skillPanels.Length; i++) //ㅜㅜ
        {
            if (ComboList[i] == KeyList[i].Skill.Count)
            {
                Debug.Log("해냈다.");
                ComboList[i] = 0;
            }
            NowKeyList[i] = KeyList[i].Skill[ComboList[i]];
        }
    }


    private void MakeSkillPanel(int skillNum)
    {
        for (int i = 0; i < KeyList[skillNum].Skill.Count; i++)
        {
            GameObject _commandPanel = Instantiate(Resources.Load<GameObject>("Prefabs/Command"), _skillPanels[skillNum].transform);
            RectTransform pos = _commandPanel.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(- 225 + 84 * i, 204);

            _commandPanel.GetComponent<LightUpSkillCmdPanel>().PanelSkillNum = skillNum;
            _commandPanel.GetComponent<LightUpSkillCmdPanel>().PanelCmdNum = i;

            string cmd = (KeyList[skillNum].Skill[i]).ToString();
            _commandTexts[skillNum] = _commandPanel.transform.GetChild(0).GetComponent<Text>();
            if (cmd != "None") _commandTexts[skillNum].text = cmd;
            else _commandTexts[skillNum].text = " ";
        }
    }
}