using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HoldingCommandData
{
    public List<string> Skill = new List<string>();
}


public class CommandManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _skillPanels;

    private SkillManager _skillManager;
    private List<int> _selectedSkillList;
    private List<HoldingCommandData> CmdList = new List<HoldingCommandData>();

    static public List<bool> IsCmdCoolTime = new List<bool>();
    private List<int> _cooltimeBySkillList = new List<int>();
    private List<int> _skillCntToActivate = new List<int>();
    private List<float> _cooltimeByTimeList = new List<float>();
    private List<GameObject> _coolTimeObject = new List<GameObject>();

    static public List<string> NowKeyList = new List<string>();
    static public List<int> ComboList = new List<int>();
    private List<bool> _comboStart = new List<bool>();



    void Awake()
    {
        Reset();
    }


    private void Start()
    {
        _skillManager = GetComponent<SkillManager>();
        _skillManager.Init();

        if (tempSkillSelect.SelectedSkillIdList.Count != 0) _selectedSkillList = tempSkillSelect.SelectedSkillIdList;
        else _selectedSkillList = new List<int> { 1, 2, 3, 4 };

        for (int i = 0; i < _skillPanels.Length; i++)
        {
            Image skillImageSr = (_skillPanels[i].transform.GetChild(0)).GetComponent<Image>();
            Text skillNameUI = (_skillPanels[i].transform.GetChild(1)).GetComponent<Text>();

            if (i < _selectedSkillList.Count)
            {
                CmdList.Add(new HoldingCommandData());
                ComboList.Add(0);
                _comboStart.Add(false);

                foreach (char cmd in _skillManager.SkillSet[_selectedSkillList[i]]._commandNormal)
                {
                    CmdList[i].Skill.Add(cmd.ToString());
                }

                MakeSkillPanel(i);

                skillNameUI.text = _skillManager.SkillSet[_selectedSkillList[i]]._skillName;
                _cooltimeBySkillList.Add(_skillManager.SkillSet[_selectedSkillList[i]]._cooltimeBySkill);
                _cooltimeByTimeList.Add(_skillManager.SkillSet[_selectedSkillList[i]]._cooltimeByTime);
                IsCmdCoolTime.Add(false);
                _coolTimeObject.Add(_skillPanels[i].transform.GetChild(2).gameObject);
                _skillCntToActivate.Add(0);

                NowKeyList.Add(CmdList[i].Skill[0]);
            }
            else
            {
                skillImageSr.color = Color.gray;
                skillNameUI.text = " ";
            }
        }
    }


    void Update()
    {
        for (int i = 0; i < _selectedSkillList.Count; i++)
        {
            if (!IsCmdCoolTime[i])
            {
                if (ComboList[i] == 1) _comboStart[i] = true;

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
            else
            {
                NowKeyList[i] = null;
                Text coolTimeBySkillText = _coolTimeObject[i].transform.GetChild(0).gameObject.GetComponent<Text>();
                coolTimeBySkillText.text = _skillCntToActivate[i].ToString();
                if (_skillCntToActivate[i] == 0) SkillActivation(i);
            }
        }
    }


    private void ComboSucceeded(int skillNum)
    {
        ComboList[skillNum] = 0;
        _comboStart[skillNum] = false;

        _skillManager.SkillSet[_selectedSkillList[skillNum]].SkillUse();
        WaitForCoolTime(skillNum);

        for (int i = 0; i < _selectedSkillList.Count; i++)
        {
            if (IsCmdCoolTime[i] && skillNum != i)
            {
                _skillCntToActivate[i]--;
            }
        }
        UltimateCharge.UltCharge++;
    }


    public void ComboFailed(int skillNum)
    {
        ComboList[skillNum] = 0;
        _comboStart[skillNum] = false;
    }


    private void WaitForCoolTime(int skillNum)
    {
        IsCmdCoolTime[skillNum] = true;

        _coolTimeObject[skillNum].SetActive(true);

        _skillCntToActivate[skillNum] = _skillManager.SkillSet[_selectedSkillList[skillNum]]._cooltimeBySkill;
        StartCoroutine(WaitForCoolTimeByTimeCor(skillNum));
    }

    
    IEnumerator WaitForCoolTimeByTimeCor(int skillNum)
    {
        float cool = _skillManager.SkillSet[_selectedSkillList[skillNum]]._cooltimeByTime;
        Image coolTimeImg = _coolTimeObject[skillNum].GetComponent<Image>();

        coolTimeImg.fillAmount = 1;

        float remain = cool;
        while (0 < remain)
        {
            coolTimeImg.fillAmount = remain / cool;
            remain -= Time.deltaTime;

            if (!IsCmdCoolTime[skillNum])
            {
                break;
            }
            yield return null;
        }
        SkillActivation(skillNum);
    }


    private void SkillActivation(int skillNum)
    {
        IsCmdCoolTime[skillNum] = false;
        _skillCntToActivate[skillNum] = 0;

        GameObject coolTimeImg = _skillPanels[skillNum].transform.GetChild(2).gameObject;
        coolTimeImg.SetActive(false);
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
            if (cmd != "-") _cmdText.text = cmd;
            else _cmdText.text = "";
        }
    }


    private void Reset()
    {
        ComboList.Clear();
        NowKeyList.Clear();
    }
}