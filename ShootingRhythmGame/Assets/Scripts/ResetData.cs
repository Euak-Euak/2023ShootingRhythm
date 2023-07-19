using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    void Start()
    {
        PlayerDataManager.Instance._money = 0;
        PlayerDataManager.Instance.NormalDamagePlus = 0;
        PlayerDataManager.Instance.SkillDamagePlus = 0;
        PlayerDataManager.Instance.RoundType = GameRoundType.None;
        PlayerDataManager.Instance.UltimateMinus = 0;
        PlayerDataManager.Instance.InvincibilityTime = 0;
        PlayerDataManager.Instance.MoneyPlus = 0;
        PlayerDataManager.Instance.PlayerHP = 3;

        PlayerDataManager.Instance._haveSkill.Clear();
        PlayerDataManager.Instance._useSkill.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
