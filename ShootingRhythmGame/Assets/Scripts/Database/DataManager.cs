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

    private void Awake()
    {
        _commandData = new CommandData();
        _coolTimeData = new CoolTimeData();
        _skillData = new SkillData();
        _userData = new UserData();
        _upgradeMoneyData = new UpgradeMoneyData();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
