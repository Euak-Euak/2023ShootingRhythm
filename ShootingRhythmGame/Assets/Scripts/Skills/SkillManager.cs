using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Dictionary<int, PlayerSkill> SkillSet;

    void Start()
    {
        SkillSet = new Dictionary<int, PlayerSkill>();
        DataManager.Instance.OpenDB();
        Debug.Log(DataManager.Instance.SkillCount());
        for (int ID = 1; ID < DataManager.Instance.SkillCount(); ++ID)
        {
            PlayerSkill skill;
            switch (ID)
            {
                case 1:
                    skill = gameObject.AddComponent<TestSkill>();
                    break;
                default:
                    skill = gameObject.AddComponent<TestSkill>();
                    break;
            }
            skill.Init(ID);

            Debug.Log(skill + " " + ID);

            SkillSet.Add(ID, skill);
        }

        DataManager.Instance.CloseDB();
    }
}
