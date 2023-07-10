using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Dictionary<int, PlayerSkill> SkillSet;
    public Sprite _bulletSprite;

    public void Init()
    {
        SkillSet = new Dictionary<int, PlayerSkill>();
        DataManager.Instance.OpenDB();
        Debug.Log(DataManager.Instance.SkillCount());

        AddSkill<TestSkill>(1);
        
        DataManager.Instance.CloseDB();
    }

    private void AddSkill<T>(int ID) where T : PlayerSkill
    {
        PlayerSkill skill = gameObject.AddComponent<T>();
        skill.Init(ID);
        skill._bulletSprite = _bulletSprite;
        SkillSet.Add(ID, skill);
    }
}