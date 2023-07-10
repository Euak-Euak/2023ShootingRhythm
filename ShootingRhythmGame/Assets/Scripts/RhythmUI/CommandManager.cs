using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HoldingCommandData
{
    public List<KeyCode> Skill = new List<KeyCode>();
}


public class CommandManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _skillPanels;
    private List<HoldingCommandData> CmdList = new List<HoldingCommandData>();

    //private List<string> _skillName = new List<string>() {"러다이트 운동", "냐냐냐", "로맨틱한언어들을많이들려드릴께요이제제이름을알려드리게ㅖㅆ습니다"};
    private KeyCode[] skill_1 = { KeyCode.A, KeyCode.S, KeyCode.None, KeyCode.A, KeyCode.S, KeyCode.None, };
    private KeyCode[] skill_2 = { KeyCode.A, KeyCode.A, KeyCode.A, KeyCode.A, KeyCode.D, KeyCode.D, KeyCode.D, KeyCode.D };
    private KeyCode[] skill_3 = { KeyCode.S, KeyCode.None };
    //데이터는 문지가 어떻게 잘  주겠지
    private SkillManager _skillManager;


    static public List<KeyCode> NowKeyList = new List<KeyCode>();
    static public List<int> ComboList = new List<int>();
    private List<bool> _comboStart = new List<bool>();


    void Awake()
    {
        Reset();

        /////////////////// 덜 무식하고 유연한 방식으로 바꾸기
        for (int i = 0; i < _skillPanels.Length; i++)
        {
            CmdList.Add(new HoldingCommandData());
            ComboList.Add(0);
            _comboStart.Add(false);
        }

        foreach (KeyCode item in skill_1) CmdList[0].Skill.Add(item);
        //foreach (KeyCode item in skill_2) CmdList[1].Skill.Add(item);
        //foreach (KeyCode item in skill_3) CmdList[2].Skill.Add(item);
        ////////////////////


    }


    private void Start()
    {
        _skillManager = gameObject.AddComponent<SkillManager>();
        _skillManager.Init();
        for (int i = 0; i < _skillPanels.Length; i++)
        {
            MakeSkillPanel(i);
            Text skillNameTextUI = (_skillPanels[i].transform.GetChild(1)).GetComponent<Text>();
            skillNameTextUI.text = _skillManager.SkillSet[i+1]._skillName;

            NowKeyList.Add(CmdList[i].Skill[0]);
        }
        //Debug.Log(_skillManager.SkillSet[1]._skillName);

    }


    void Update()
    {
        for (int i = 0; i < _skillPanels.Length; i++) //ㅜㅜ
        {
            if (ComboList[i] == 1)  _comboStart[i] = true;

            if (ComboList[i] == CmdList[i].Skill.Count)
            {
                ComboSucceeded(i);
            }

            else if (_comboStart[i] && ComboList[i] == 0)
            {
                ComboFailed(i);
            }

            NowKeyList[i] = CmdList[i].Skill[ComboList[i]];
        }
    }


    private void ComboSucceeded(int skillNum)
    {
        Debug.Log((skillNum + 1) + "해냈다.");
        ComboList[skillNum] = 0;
        _comboStart[skillNum] = false;
    }


    public void ComboFailed(int skillNum)
    {
        Debug.Log((skillNum + 1) + "실패했군.");
        ComboList[skillNum] = 0;
        _comboStart[skillNum] = false;
    }


    private void MakeSkillPanel(int skillNum)
    {
        for (int i = 0; i < CmdList[skillNum].Skill.Count; i++)
        {
            GameObject _cmdPanel = Instantiate(Resources.Load<GameObject>("Prefabs/Command"), _skillPanels[skillNum].transform);
            RectTransform pos = _cmdPanel.GetComponent<RectTransform>();
            pos.anchoredPosition = new Vector2(- 225 + 84 * i, 204);

            _cmdPanel.GetComponent<LightUpSkillCmdPanel>().PanelSkillNum = skillNum;
            _cmdPanel.GetComponent<LightUpSkillCmdPanel>().PanelCmdNum = i;

            string cmd = (CmdList[skillNum].Skill[i]).ToString();
            Text _cmdText = _cmdPanel.transform.GetChild(0).GetComponent<Text>();
            if (cmd != "None") _cmdText.text = cmd;
            else _cmdText.text = "";
        }
    }


    private void Reset()
    {
        ComboList.Clear();
        NowKeyList.Clear();
    }
}