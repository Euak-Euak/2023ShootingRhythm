using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameRoundType
{
    None,
    Stage1Field,
    Stage1Boss,
    Stage2Field,
    Stage2Boss,
    Stage3Field,
    Stage3Boss,
    Stage4Field,
    Stage4Boss,
    Stage5Field,
    Stage5Boss,
    LastBoss,
}

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public int _money = 0;
    public int _skillPoint = 0;

    public List<int> _haveSkill = new List<int>();
    public List<int> _useSkill = new List<int>();

    public GameRoundType RoundType;

    void Start()
    {
        if(PlayerPrefs.HasKey(ConstData.PlayerSkillPointDataKey))
        _skillPoint = PlayerPrefs.GetInt(ConstData.PlayerSkillPointDataKey);
    }
}
