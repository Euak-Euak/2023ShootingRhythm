using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private CommandData _commandData;
    private CoolTimeData _coolTimeData;
    private SkillData _skillData;
    private UpgradeMoneyData _upgradeMoneyData;
    private UserData _userData;
    private SkillGrowthValueData _skillGrowthValueData;

    new void Awake()
    {
        base.Awake();
        _commandData = new CommandData();
        _coolTimeData = new CoolTimeData();
        _skillData = new SkillData();
        _userData = new UserData();
        _upgradeMoneyData = new UpgradeMoneyData();
        _skillGrowthValueData = new SkillGrowthValueData();
    }

    public void OpenDB()
    {
        _commandData.Open();
        _coolTimeData.Open();
        _skillData.Open();
        _userData.Open();
        _upgradeMoneyData.Open();
        _skillGrowthValueData.Open();
    }

    public void CloseDB() 
    {
        _commandData.Close();
        _coolTimeData.Close();
        _skillData.Close();
        _userData.Close();
        _upgradeMoneyData.Close();
        _skillGrowthValueData.Close();
    }

    public int SkillCount()
    {
        return _skillData.SkilCountName();
    }

    public string SkillName(int ID)
    {
        return _skillData.SkillName(ID);
    }

    public int BulletType(int ID)
    {
        return _skillData.BulletType(ID);
    }

    public bool IsPowerUp(int ID)
    {
        return _userData.GetPowerUp(ID);
    }

    public string CommandNormal(int ID)
    {
        return _commandData.NormalCommand(ID);
    }

    public string CommandPowerUp(int ID)
    {
        return _commandData.PowerUpCommand(ID);
    }

    public string SkillImage(int ID)
    {
        return _skillData.SkillImage(ID);
    }

    public int SkillValue(int ID)
    {
        int initValue = _skillGrowthValueData.InitValue(ID);
        int skillLevel = _userData.GetSkillLevel(ID);
        int growthValue = _skillGrowthValueData.GrowthValue(ID);
        int skillValue = initValue + ((skillLevel - 1) * growthValue);
        return skillValue;
    }

    public int NextSkillValue(int ID)
    {
        int initValue = _skillGrowthValueData.InitValue(ID);
        int skillLevel = _userData.GetSkillLevel(ID);
        int growthValue = _skillGrowthValueData.GrowthValue(ID);
        int skillValue = initValue + ((skillLevel) * growthValue);
        return skillValue;
    }

    public int CooltimeBySkill(int ID)
    {
        return _coolTimeData.SkillCountCool(ID);
    }
    public float CooltimeByTime(int ID)
    {
        return _coolTimeData.RealTimeCool(ID);
    }


    //스킬 숫자 기본치
    public int SkillInitValue(int ID)
    {
        _skillGrowthValueData.Open();
        return _skillGrowthValueData.InitValue(ID);
    }

    //스킬 숫자 성장치
    public int SkillGrowthValue(int ID)
    {
        return _skillGrowthValueData.GrowthValue(ID);
    }
}
