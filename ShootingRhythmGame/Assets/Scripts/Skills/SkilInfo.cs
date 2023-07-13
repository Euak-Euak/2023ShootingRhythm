using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilInfo : MonoBehaviour
{
    [SerializeField] private Text SkillNameText;
    [SerializeField] private Text SkillDescriptText;
    [SerializeField] private Text SkillUseDescriptText;
    [SerializeField] private Text PowerDescriptText;
    [SerializeField] private Text SkillLevelText;
    [SerializeField] private Text CommandText;
    [SerializeField] private Text PowerUpCommandText;
    [SerializeField] private Text CoolTimeCommandText;
    [SerializeField] private Text UpgradeMoneyText;
    [SerializeField] private Text SkillGrowthText;

    [Header("Buttons")]
    [SerializeField] public Button PowerUpOnOffButton;
    [SerializeField] public Button LevelUpButton;
    [SerializeField] public Button GoBackButton;

    [Header("ID")]
    public int ID;

    private Dictionary<int, SkillContent> _skillInfoByID = new Dictionary<int, SkillContent>();


    private void Start()
    {
        PowerUpOnOffButton.onClick.AddListener(OnClickPowerUpOnOffButton);
        LevelUpButton.onClick.AddListener(OnClickLevelUpButton);
        SkillNameText.text = string.Empty;
        SkillDescriptText.text = string.Empty;
        SkillUseDescriptText.text = string.Empty;
        PowerDescriptText.text = string.Empty;
        SkillLevelText.text = string.Empty;
        CommandText.text = string.Empty;
        PowerUpCommandText.text = string.Empty;
        CoolTimeCommandText.text = string.Empty;
        UpgradeMoneyText.text = string.Empty;
        SkillGrowthText.text = string.Empty;
        PowerUpOnOffButton.gameObject.SetActive(false);
        LevelUpButton.gameObject.SetActive(false);
    }

    public void OnClickPowerUpOnOffButton()
    {
        DataManager.Instance.OpenDB();
        DataManager.Instance.SetPowerUpChange(ID);
        _skillInfoByID[ID].PowerUpChange();
        DataManager.Instance.CloseDB();
    }

    public void OnClickLevelUpButton()
    {
        DataManager.Instance.OpenDB();

        if (DataManager.Instance.SkillLevel(ID) >= 20)
        {
            DataManager.Instance.CloseDB();
            return;
        }

        DataManager.Instance.SetSkillLevelUp(ID);
        _skillInfoByID[ID].SkillLevelChange();
        SkillLevelText.text = DataManager.Instance.SkillLevel(ID).ToString();
        UpgradeMoneyText.text = $"{DataManager.Instance.SkillUpgradeMoney(ID)}원";

        if (DataManager.Instance.SkillLevel(ID) == 15)
        {
            OverLevel15();
            DataManager.Instance.CloseDB();
            DataManager.Instance.OpenDB();
            DataManager.Instance.SetPowerUpChange(ID);
            _skillInfoByID[ID].PowerUpChange();
        }
        if (DataManager.Instance.SkillLevel(ID) == 20)
        {
            OverLevel20();
        }
        DataManager.Instance.CloseDB();
    }

    public void UpdateInfo(int _id)
    {
        if (_id == ID)
            return;
        ID = _id;
        DataManager.Instance.OpenDB();
        if (DataManager.Instance.SkillLevel(ID) == 0)
        {
            SkillNameText.text = "???";
            SkillDescriptText.text = "아직 획득하지 않은 스킬입니다.";
            SkillUseDescriptText.text = "???";
            PowerDescriptText.text = "???";
            SkillLevelText.text = "";
            CommandText.text = "???";
            PowerUpCommandText.text = "???";
            CoolTimeCommandText.text = "??번 / ??초";
            UpgradeMoneyText.text = "???";
            SkillGrowthText.text = "???";
            PowerUpOnOffButton.gameObject.SetActive(false);
            LevelUpButton.gameObject.SetActive(false);
            DataManager.Instance.CloseDB();
            return;
        }

        SkillNameText.text = DataManager.Instance.SkillName(ID);
        SkillDescriptText.text = DataManager.Instance.SkillDescript(ID);
        SkillUseDescriptText.text = DataManager.Instance.SkillUseDescript(ID);
        SkillLevelText.text = DataManager.Instance.SkillLevel(ID).ToString();
        CommandText.text = DataManager.Instance.CommandNormal(ID);
        CoolTimeCommandText.text = $"{DataManager.Instance.CooltimeBySkill(ID)}번 / {DataManager.Instance.CooltimeByTime(ID)}초";
        UpgradeMoneyText.text = $"{DataManager.Instance.SkillUpgradeMoney(ID)}원";
        SkillGrowthText.text = $"{DataManager.Instance.SkillInitValue(ID)}/{DataManager.Instance.SkillGrowthValue(ID)}";
        LevelUpButton.gameObject.SetActive(true);


        if (DataManager.Instance.SkillLevel(ID) >= 15)
        {
            OverLevel15();
        }
        else
        {
            PowerDescriptText.text = "???";
            PowerUpCommandText.text = "???";
            PowerUpOnOffButton.gameObject.SetActive(false);
        }
        DataManager.Instance.CloseDB();
    }

    private void OverLevel15()
    {
        PowerDescriptText.text = DataManager.Instance.SkillPowerUpDescript(ID);
        PowerUpCommandText.text = DataManager.Instance.CommandPowerUp(ID);
        PowerUpOnOffButton.gameObject.SetActive(true);
        if (DataManager.Instance.SkillLevel(ID) >= 20)
            OverLevel20();
    }

    private void OverLevel20()
    {
        LevelUpButton.gameObject.SetActive(false);
    }

    public void GetSkillInfoDictionary(Dictionary<int, SkillContent> dic)
    {
        _skillInfoByID = dic;
    }

    public void SetGoBackButton(Action action)
    {
        GoBackButton.onClick.AddListener(action.Invoke);
    }
}
