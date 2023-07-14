using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public int _money = 0;
    public int _skillPoint = 0;

    public List<int> _haveSkill = new List<int>();
    public List<int> _useSkill = new List<int>();

    void Start()
    {
        if(PlayerPrefs.HasKey(ConstData.PlayerMoneyDataKey))
            _money = PlayerPrefs.GetInt(ConstData.PlayerMoneyDataKey);

        if(PlayerPrefs.HasKey(ConstData.PlayerSkillPointDataKey))
        _skillPoint = PlayerPrefs.GetInt(ConstData.PlayerSkillPointDataKey);
    }
}
